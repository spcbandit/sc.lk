using SC.LK.Application.Domains.InternalConnectors.BillingService;

namespace SC.LK.Application.Domains.Responses.Market;

public class GetItemForSaleByIdResponse:BaseResponse
{
    public ItemForSaleResponse ItemForSaleResponse { get; set; }
}