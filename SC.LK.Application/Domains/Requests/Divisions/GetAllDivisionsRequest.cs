using MediatR;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Domains.Requests.Divisions;

public class GetAllDivisionsRequest : IRequest<GetAllDivisionsResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
}