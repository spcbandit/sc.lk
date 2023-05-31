using MediatR;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Domains.Requests.Finance;

public class GetBillingFaceByIdRequest : IRequest<GetBillingFaceByIdResponse>
{
    /// <summary>
    /// BillingFaceId
    /// </summary>
    public Guid BillingFaceId { get; set; }
}