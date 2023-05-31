using MediatR;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Domains.Requests.Tickets;

public class UpdateStatusTicketRequest : IRequest<UpdateStatusTicketResponse>
{
    public  Guid TicketId { get; set; }
    
    public TicketStatusType TicketStatusType { get; set; }
}