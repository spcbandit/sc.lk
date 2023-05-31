using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Entities;

public class TicketEntity : BaseEntity
{
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