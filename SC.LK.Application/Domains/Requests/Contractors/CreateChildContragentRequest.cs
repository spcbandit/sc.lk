using MediatR;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Domains.Requests.Contractors;

public class CreateChildContragentRequest : IRequest<CreateChildContragentResponse>
{
    public Guid UserId { get; set; }
    public Guid ContractorId { get; set; }
    public string ContractorINN { get; set; }
    public string ContractorName { get; set; }
    public ContractorType ContractorType { get; set; }
}