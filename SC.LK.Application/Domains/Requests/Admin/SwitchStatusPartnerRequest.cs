using MediatR;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Domains.Requests.Admin;

public class SwitchStatusPartnerRequest : IRequest<SwitchStatusPartnerResponse>
{
    public Guid ContractorId { get; set; }
    public bool StatusPartner { get; set; }
}