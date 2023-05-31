using MediatR;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Domains.Requests.TerminalLicense;

public class ReleaseLicenceFromTerminalRequest : IRequest<ReleaseLicenceFromTerminalResponse>
{
    public Guid KontragentId { get; set; }
    
    public Guid TerminalId { get; set; }
    
    public Guid LicenceId { get; set; }
    
    public string UpdateBy { get; set; }
}