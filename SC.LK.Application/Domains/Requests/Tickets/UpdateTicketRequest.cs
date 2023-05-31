using MediatR;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Domains.Requests.Tickets;

public class UpdateTicketRequest : IRequest<UpdateTicketResponse>
{
    public Guid TicketId { get; set; }
    
    /// <summary>
    /// TicketType
    /// </summary>
    public TicketType TicketType { get; set; }

    /// <summary>
    /// TicketStatusType
    /// </summary>
    public TicketStatusType TicketStatusType { get; set; }
    
    /// <summary>
    /// FromUser
    /// </summary>
    public Guid FromUser { get; set; }
    
    /// <summary>
    /// FromContragent
    /// </summary>
    public Guid FromContragent { get; set; }
    
    /// <summary>
    /// Message
    /// </summary>
    public string? Message { get; set; }
}