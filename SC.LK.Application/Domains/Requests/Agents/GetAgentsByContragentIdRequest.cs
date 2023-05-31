using MediatR;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Domains.Requests.Agents;

public class GetAgentsByContragentIdRequest: IRequest<GetAgentsByContragentIdResponse>
{
    public Guid ContragentId { get; set; }
}