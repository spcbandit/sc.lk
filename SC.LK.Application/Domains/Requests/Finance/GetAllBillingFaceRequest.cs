using MediatR;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Domains.Requests.Finance;

public class GetAllBillingFaceRequest : IRequest<GetAllBillingFaceResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
}