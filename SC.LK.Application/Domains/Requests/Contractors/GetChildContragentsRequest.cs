using MediatR;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Domains.Requests.Contractors;

public class GetChildContragentsRequest : IRequest<GetChildContragentsResponse>
{
    public Guid MainContractorId { get; set; }
    public Guid UserId { get; set; }
}