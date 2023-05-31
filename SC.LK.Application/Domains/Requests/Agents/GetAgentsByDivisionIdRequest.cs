using MediatR;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class GetAgentsByDivisionIdRequest : IRequest<GetAgentsByDivisionIdResponse>
{
    public Guid DivisionId { get; set; }
}