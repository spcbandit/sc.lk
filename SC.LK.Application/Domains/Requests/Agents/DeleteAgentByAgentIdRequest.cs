using MediatR;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class DeleteAgentByAgentIdRequest : IRequest<DeleteAgentByAgentIdResponce>
{
    public Guid AgentId { get; set; }
}

