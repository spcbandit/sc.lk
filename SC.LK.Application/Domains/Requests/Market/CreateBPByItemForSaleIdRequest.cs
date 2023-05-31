using MediatR;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Domains.Requests.Market;

public class CreateBPByItemForSaleIdRequest:IRequest<CreateBPByItemForSaleIdResponse>
{
    public Guid ItemId { get; set; }
    public Guid ContragentId { get; set; }
}