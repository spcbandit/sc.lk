using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Handlers.ConfigurationVersion;

public class CreateConfigurationsVersionHandler : IRequestHandler<CreateConfigurationsVersionRequest, CreateConfigurationsVersionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public CreateConfigurationsVersionHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
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
    public async Task<CreateConfigurationsVersionResponse> Handle(CreateConfigurationsVersionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
     
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

        // добавить данные на вход
        var configuration = new ConfigurationVersionView()
        {
            Proceses = proceses,
            ConfigurationId = request.ConfigurationId,
            IsActive = request.IsActive,
            JsonHeader = "sting",
            UpdateBy = "string",
        };
        var res = await  _repositoryConfigurationServiceAdaptor.AddConfigurationVersionAsync(configuration);

        if (res != null)
            return new CreateConfigurationsVersionResponse() {Success = true};
        else
            return new CreateConfigurationsVersionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}