using MediatR;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Domains.Requests.Market;

public class NotifyAdminItemBuyRequest:IRequest<NotifyAdminItemBuyResponse>
{
    public List<Items> Items { get; set; }
    public string ContragentName { get; set; }
}

public class Items
{
    public Guid ItemGuid { get; set; }
    public int Quantity { get; set; }
}