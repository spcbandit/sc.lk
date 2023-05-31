using MediatR;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Domains.Requests.Tickets;

public class GetAllTicketsRequest : IRequest<GetAllTicketsResponse>
{
    public Guid ContractorId { get; set; }
}