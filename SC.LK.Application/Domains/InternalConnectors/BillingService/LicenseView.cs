using SC.LK.Application.Domains.InternalConnectors.BillingService.Enums;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class LicenseView
{
    [Newtonsoft.Json.JsonProperty("licenseId")]
    public System.Guid? LicenseId { get; set; }

    [Newtonsoft.Json.JsonProperty("provider")]
    public System.Guid? Provider { get; set; }

    [Newtonsoft.Json.JsonProperty("description")]
    public string Description { get; set; }

    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid? KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("terminalId")]
    public System.Guid? TerminalId { get; set; }

    [Newtonsoft.Json.JsonProperty("subscriptionsEnd")]

public System.DateTimeOffset SubscriptionsEnd { get; set; }

    [Newtonsoft.Json.JsonProperty("isActive")]
    public bool IsActive { get; set; }
    
    [Newtonsoft.Json.JsonProperty("updatedBy")]
    public string UpdatedBy { get; set; }
    
    [Newtonsoft.Json.JsonProperty("licenceType")]
    public LicenceType LicenceType { get; set; }
}