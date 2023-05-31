using MediatR;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class GetTerminalsByContractorIdRequest : IRequest<GetTerminalsByContractorIdResponse>
{
    public Guid ContractorId { get; set; }
}