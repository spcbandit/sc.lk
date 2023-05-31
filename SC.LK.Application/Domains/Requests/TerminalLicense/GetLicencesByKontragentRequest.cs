using MediatR;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Domains.Requests.TerminalLicense;

public class GetLicencesByKontragentRequest : IRequest<GetLicencesByKontragentResponse>
{
    public Guid KontragentId { get; set; }
}