using MediatR;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class GetBusinessProcessByIdRequest : IRequest<GetBusinessProcessByIdResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
    
    /// <summary>
    /// BusinessProcessId
    /// </summary>
    public Guid BusinessProcessId { get; set; }
}