using MediatR;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Domains.Requests.Tickets;

public class DeleteTicketRequest: IRequest<DeleteTicketResponse>
{
    public Guid TicketId { get; set; }
}