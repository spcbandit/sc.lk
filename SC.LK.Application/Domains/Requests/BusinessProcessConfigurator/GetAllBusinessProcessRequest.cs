using MediatR;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class GetAllBusinessProcessRequest : IRequest<GetAllBusinessProcessResponse>
{
/// <summary>
/// ContractorId
/// </summary>
public Guid ContractorId { get; set; }

}