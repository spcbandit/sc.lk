using MediatR;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Domains.Requests.Configurations;

public class GetAllDivisionsTerminalsRequest: IRequest<GetAllDivisionsTerminalsResponse>
{
    public Guid ContractorId { get; set; }
}