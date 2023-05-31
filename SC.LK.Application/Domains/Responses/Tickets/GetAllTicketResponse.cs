using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Tickets;

public class GetAllTicketsResponse : BaseResponse
{
    public List<TicketEntity> Tickets { get; set; }
}