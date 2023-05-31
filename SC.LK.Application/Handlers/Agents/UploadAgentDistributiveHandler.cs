using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Handlers.Agents;

public class UploadAgentDistributiveHandler:IRequestHandler<UploadAgentDistributiveRequest, UploadAgentDistributiveResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;

    public UploadAgentDistributiveHandler(IRepositoryConfigurationServiceAdaptor repository, IISClient iisClient)
    {
        _rcClient = repository;
        _iisClient = iisClient;
    }

    public async Task<UploadAgentDistributiveResponse> Handle(UploadAgentDistributiveRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        var distributive = await _rcClient.UploadAgentDistributive(request);
        if (distributive != null)
        {
            return new UploadAgentDistributiveResponse()
            {
                Success = true, 
                Version = distributive.Version, 
                DistributiveId = distributive.DistributiveId,
                ErrorMessage = distributive.ErrorMessage
            };
        }

        return new UploadAgentDistributiveResponse() { Success = false, ErrorMessage = distributive.ErrorMessage };

    }
}