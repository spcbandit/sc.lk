using MediatR;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Domains.Requests.Finance;

public class DeleteBillingFaceRequest : IRequest<DeleteBillingFaceResponse>
{
    /// <summary>
    /// BillingFaceId
    /// </summary>
    public Guid BillingFaceId { get; set; }
}