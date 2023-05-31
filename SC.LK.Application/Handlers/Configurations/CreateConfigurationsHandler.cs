using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Configurations;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Handlers.Configurations;

public class CreateConfigurationsHandler: IRequestHandler<CreateConfigurationsRequest, CreateConfigurationsResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public CreateConfigurationsHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
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
    public async Task<CreateConfigurationsResponse> Handle(CreateConfigurationsRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var configurationResponse = new ConfigurationView()
        {
            KontragentId = request.ContractorId, ConfigurationDescription = request.Description,
            ConfigurationName = request.Name, UpdateBy = "string"
        };
        var requestConfigurationId = await _repositoryConfigurationServiceAdaptor.AddConfigurationAsync(configurationResponse);
        
        var configurationVersionResponse = new ConfigurationVersionView()
        {
            Proceses = new List<ConfigurationsBusinessProcessView>(),
            Update = DateTime.Now,
            ConfigurationId = requestConfigurationId,
            ConfigurationVersionNumber = 0,
            IsActive = false,
            JsonHeader = "sting",
            UpdateBy = "string",
        };
        var res = await _repositoryConfigurationServiceAdaptor.AddConfigurationVersionAsync(configurationVersionResponse);
        
        if (res != null)
            return new CreateConfigurationsResponse() {Success = true};
        else
            return new CreateConfigurationsResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}