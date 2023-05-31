using MediatR;
using SC.LK.Application.Domains.InternalConnectors.BillingService.Enums;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Domains.Requests.Admin;

public class AddLicenseRequest : IRequest<AddLicenseResponse>
{
    [Newtonsoft.Json.JsonProperty("provider", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Provider { get; set; }

    [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Description { get; set; }

    [Newtonsoft.Json.JsonProperty("kontragentId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("terminalId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid TerminalId { get; set; }

    [Newtonsoft.Json.JsonProperty("subscriptionsEnd", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.DateTimeOffset SubscriptionsEnd { get; set; }

    [Newtonsoft.Json.JsonProperty("isActive", Required = Newtonsoft.Json.Required.Always)]
    public bool IsActive { get; set; }
    
    [Newtonsoft.Json.JsonProperty("updatedBy", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string UpdatedBy { get; set; }
    
    [Newtonsoft.Json.JsonProperty("licenceType", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public LicenceType LicenceType { get; set; }
}