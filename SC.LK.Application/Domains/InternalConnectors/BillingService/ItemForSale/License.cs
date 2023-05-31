using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class License
{
    [JsonProperty("licenseId")]
    public Guid? licenseId { get; set; }
    [JsonProperty("provider")]
    public Guid? provider { get; set; }
    [JsonProperty("description")]
    public string description { get; set; }
    [JsonProperty("kontragentId")]
    public Guid? kontragentId { get; set; }
    [JsonProperty("terminalId")]
    public Guid? terminalId { get; set; }
    [JsonProperty("subscriptionsEnd")]
    public DateTime subscriptionsEnd { get; set; }
    [JsonProperty("isActive")]
    public bool isActive { get; set; }
    [JsonProperty("updatedBy")]
    public string updatedBy { get; set; }
    [JsonProperty("licenceType")]
    public int licenceType { get; set; }
    [JsonProperty("licenseHistoryes")]
    public List<LicenseHistorye> licenseHistoryes { get; set; }
    [JsonProperty("priceList")]
    public string priceList { get; set; }
}