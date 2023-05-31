using MediatR;
using SC.LK.Application.Domains.InternalConnectors.BillingService.Enums;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Domains.Requests.TerminalLicense;

public class UpdateLicenseRequest : IRequest<UpdateLicenseResponse>
{
    public System.Guid LicenseId { get; set; }
    
    public System.Guid Provider { get; set; }
    
    public string Description { get; set; }
    
    public System.Guid KontragentId { get; set; }
    
    public System.Guid TerminalId { get; set; }
    
    public System.DateTimeOffset SubscriptionsEnd { get; set; }
    
    public bool IsActive { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public LicenceType LicenceType { get; set; }
}