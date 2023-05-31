using MediatR;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class SetAgentsInDivisionRequest: IRequest<SetAgentsInDivisionResponse>
{
    public Guid DivisionId { get; set; }
    public List<Guid> AgentsId { get; set; }
}