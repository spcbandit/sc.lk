using MediatR;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Domains.Requests.TerminalLicense;

public class DeleteTerminalLicenseRequest : IRequest<DeleteTerminalLicenseResponse>
{
    public Guid? LicenseId { get; set; }
    
    public string UpdatedBy { get; set; }
}