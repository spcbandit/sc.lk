using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class UploadTerminalDistributiveHandler:IRequestHandler<UploadTerminalDistributiveRequest, UploadTerminalDistributiveResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;

    public UploadTerminalDistributiveHandler(IRepositoryConfigurationServiceAdaptor rcClient, IISClient iisClient)
    {
        _rcClient = rcClient;
        _iisClient = iisClient;
    }

    public async Task<UploadTerminalDistributiveResponse> Handle(UploadTerminalDistributiveRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        var distributive = await _rcClient.UploadTerminalDistributive(request);
        if (distributive != null)
        {
            return new UploadTerminalDistributiveResponse()
            {
                Success = true, 
                Version = distributive.Version, 
                DistributiveId = distributive.DistributiveId, 
                ErrorMessage = distributive.ErrorMessage
            }; 
        }

        return new UploadTerminalDistributiveResponse() { Success = false, ErrorMessage = distributive.ErrorMessage };
    }
}