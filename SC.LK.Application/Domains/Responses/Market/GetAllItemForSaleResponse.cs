using SC.LK.Application.Domains.InternalConnectors.BillingService;

namespace SC.LK.Application.Domains.Responses.Market;

public class GetAllItemForSaleResponse:BaseResponse
{
    public List<ItemForSaleResponse> ItemForSaleResponse { get; set; }
}