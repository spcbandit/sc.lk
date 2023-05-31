using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Handlers.ConfigurationVersion;

public class ActivateConfigurationVersionHandler : IRequestHandler<ActivateConfigurationVersionRequest, ActivateConfigurationVersionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public ActivateConfigurationVersionHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
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
    public async Task<ActivateConfigurationVersionResponse> Handle(ActivateConfigurationVersionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var res = await _repositoryConfigurationServiceAdaptor.ActivateConfigurationVersionAsync(request.ConfigurationVersionId);
        
        if (res != null)
            return new ActivateConfigurationVersionResponse() {Success = true};
        else
            return new ActivateConfigurationVersionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}