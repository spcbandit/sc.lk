using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Requests.Configurations;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Handlers.Configurations;

public class GetAllConfigurationsHandler: IRequestHandler<GetAllConfigurationsRequest, GetAllConfigurationsResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllConfigurationsHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllConfigurationsResponse> Handle(GetAllConfigurationsRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var dtoResult = new List<DtoResult>();
        
        var requestConfigurations = await 
            _repositoryConfigurationServiceAdaptor.GetConfigurationByKontragentIdAsync(request.ContractorId);

        var configurationsId = requestConfigurations.Select(x => x.ConfigurationId).ToList();
        foreach (var configurationId in configurationsId)
        {
            var configuration = requestConfigurations.FirstOrDefault(x => x.ConfigurationId == configurationId);
            
            var requestConfigurationsVersions =
                await _repositoryConfigurationServiceAdaptor.GetConfigurationVersionsByConfigurationIdAsync(configurationId);
           
            if (requestConfigurationsVersions.FirstOrDefault(x => x.IsActive) == null)
            {
                var versionId = requestConfigurationsVersions
                    .OrderByDescending(x => x.Update)
                    .Select(x=>x.ConfigurationVersionId).FirstOrDefault();
                
                dtoResult.Add(new DtoResult()
                {
                    IdConfig = configurationId,
                    IdVersion = versionId,
                    NameConfig = configuration.ConfigurationName,
                    Version = "Нет актуальной версии"
                });
            }
            else
            {
                var versionRes = requestConfigurationsVersions
                    .Where(x => x.IsActive == true)
                    .Select(x => (x.ConfigurationVersionId,x.ConfigurationVersionNumber))
                    .FirstOrDefault();
                dtoResult.Add(new DtoResult()
                {
                    IdConfig = configurationId,
                    IdVersion = versionRes.ConfigurationVersionId,
                    NameConfig = configuration.ConfigurationName,
                    Version = versionRes.ConfigurationVersionNumber.ToString()
                });
            }
        }
         
        if (dtoResult != null)
            return new GetAllConfigurationsResponse() {Success = true, DtoResult = dtoResult};
        else
            return new GetAllConfigurationsResponse() {Success = false, ErrorMessage = MessageResource.FailedGetConfigurations};
    }
}