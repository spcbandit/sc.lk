using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class CopyBusinessProcessHandler: IRequestHandler<CopyBusinessProcessRequest, CopyBusinessProcessResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Копирование businessProcess
    /// </summary>
    /// <param name="repositoryConfigurationServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public CopyBusinessProcessHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }
    
    /// <summary>
    /// Копирование businessProcess
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CopyBusinessProcessResponse> Handle(CopyBusinessProcessRequest request, CancellationToken cancellationToken)
    {
        try{
            //get token
            var serviceToken = await _iisClient.TokenAsync(null);
            _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

            var businessProcess =await _repositoryConfigurationServiceAdaptor
                .GetBusinessProcessByBusinessProcessIdAsync(request.IdBusinessProcess);
            
            //create businessProcess in repositoryConfigurationService
            var newBusinessProcess = new BusinessProcessView()
            {
                // ConfigurationVersions = businessProcess.ConfigurationVersions,
                IsTemplate = false,
                JsonBody = businessProcess.JsonBody,
                KontragentId = businessProcess.KontragentId,
                BusinessProcessDescription = businessProcess.BusinessProcessDescription,
                BusinessProcessName = $"{businessProcess.BusinessProcessName} new"
            };
            var requestBusinessProcess =
                await _repositoryConfigurationServiceAdaptor.AddBusinessProcessAsync(newBusinessProcess);

            if (requestBusinessProcess != null)
                return new CopyBusinessProcessResponse() {Success = true, Id = requestBusinessProcess};
            else
                return new CopyBusinessProcessResponse()
                    {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        } 
    }
}