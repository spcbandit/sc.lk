using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Handlers.Agents;

public class UpdateAgentHandler: IRequestHandler<UpdateAgentRequest, UpdateAgentResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;

    /// <summary>
    /// SetAgentsInDivisionHandler
    /// </summary>
    public UpdateAgentHandler(IRepositoryConfigurationServiceAdaptor rcClient, IISClient iisClient)
    {
        _rcClient = rcClient ?? throw new ArgumentException(nameof(rcClient));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<UpdateAgentResponse> Handle(UpdateAgentRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;

        var res = await _rcClient.UpdateAgentAsync(request.AgentId, request.Agent);

        if (res != null)
            return new UpdateAgentResponse() {Success = true,};
        else
            return new UpdateAgentResponse() {Success = false, ErrorMessage = ""};
    }
}