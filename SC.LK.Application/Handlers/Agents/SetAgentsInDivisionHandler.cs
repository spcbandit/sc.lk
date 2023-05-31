using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Handlers.Agents;

public class SetAgentsInDivisionHandler: IRequestHandler<SetAgentsInDivisionRequest, SetAgentsInDivisionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;

    /// <summary>
    /// SetAgentsInDivisionHandler
    /// </summary>
    public SetAgentsInDivisionHandler(IRepositoryConfigurationServiceAdaptor rcClient, IISClient iisClient)
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
    public async Task<SetAgentsInDivisionResponse> Handle(SetAgentsInDivisionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        
        foreach (var agentId in request.AgentsId)
        {
            var responseAgent = await _rcClient.GetAgentByAgentIdAsync(agentId);
            responseAgent.DivisionId = request.DivisionId;
            var result = await _rcClient.UpdateAgentAsync(agentId, responseAgent);
            if (result == Guid.Empty)
            {
                return new SetAgentsInDivisionResponse()
                    {Success = false, ErrorMessage = "Не удалось связать агента и подразделение"};
            }
        }
        return new SetAgentsInDivisionResponse() {Success = true};
    }
}