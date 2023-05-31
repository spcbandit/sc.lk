using MediatR;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Domains.Requests.Contractors;

public class GetContractorNameByIdRequest : IRequest<GetContractorNameByIdResponse>
{
    public Guid ContractorId { get; set; }
}