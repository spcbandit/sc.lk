using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Handlers.ConfigurationVersion;

public class UpdateConfigurationVersionHandler : IRequestHandler<UpdateConfigurationVersionRequest, UpdateConfigurationVersionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public UpdateConfigurationVersionHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateConfigurationVersionResponse> Handle(UpdateConfigurationVersionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        if (request.BusinessProceses.Count == 0)
        {
            return new UpdateConfigurationVersionResponse() {Success = false, ErrorMessage = "Вы не можете сохранить пустую конфигурацию"};
        }

        var requestConfigurationVesion = await _repositoryConfigurationServiceAdaptor
            .GetConfigurationVersionByConfigurationVersionIdAsync(request.ConfigurationVersionId);
        
        var proceses = new List<ConfigurationsBusinessProcessView>();
        
        foreach (var businessProcess in request.BusinessProceses)
        {
            var process = new ConfigurationsBusinessProcessView()
            {
                OrderNumber = businessProcess.BusinessProcessNumber,
                BusinessProcessId = businessProcess.BusinessProcessId,
            };
            proceses.Add(process);
        }

        requestConfigurationVesion.Proceses = proceses;
        requestConfigurationVesion.ConfigurationId = request.ConfigurationId;
        requestConfigurationVesion.IsActive = request.IsActive;
        requestConfigurationVesion.JsonHeader = "string";
        requestConfigurationVesion.UpdateBy = "string";

        var res = await  _repositoryConfigurationServiceAdaptor.UpdateConfigurationVersionAsync(request.ConfigurationVersionId, requestConfigurationVesion);
        
        if (res != null)
            return new UpdateConfigurationVersionResponse() {Success = true};
        else
            return new UpdateConfigurationVersionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}