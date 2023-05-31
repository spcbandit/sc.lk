using MediatR;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Domains.Requests.Market;

public class GetItemForSaleByIdRequest:IRequest<GetItemForSaleByIdResponse>
{
    public Guid ItemId { get; set; }
}