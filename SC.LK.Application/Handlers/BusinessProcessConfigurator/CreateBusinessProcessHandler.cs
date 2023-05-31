using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class CreateBusinessProcessHandler: IRequestHandler<CreateBusinessProcessRequest, CreateBusinessProcessResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;

    /// <summary>
    /// Создание businessProcess
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public CreateBusinessProcessHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Создание businessProcess
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateBusinessProcessResponse> Handle(CreateBusinessProcessRequest request, CancellationToken cancellationToken)
    {
        try{
            //get token
            var serviceToken = await _iisClient.TokenAsync(null);
            _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

            //create businessProcess in repositoryConfigurationService
            var businessProcess = new BusinessProcessView()
            {
                ConfigurationVersions = new List<ConfigurationsBusinessProcessView>(),
                IsTemplate = false,
                JsonBody = MessageResource.NoneConfiguration,
                KontragentId = request.ContractorId,
                BusinessProcessDescription = request.NameBusinessProcess,
                BusinessProcessName = request.NameBusinessProcess
            };
            var requestBusinessProcess =
                await _repositoryConfigurationServiceAdaptor.AddBusinessProcessAsync(businessProcess);

            if (requestBusinessProcess != null)
                return new CreateBusinessProcessResponse() {Success = true, IdProcess = requestBusinessProcess};
            else
                return new CreateBusinessProcessResponse()
                    {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        } 
    }
}