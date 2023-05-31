using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class LicenseHistorye
{
    [JsonProperty("licenseHistoryId")]
    public Guid? licenseHistoryId { get; set; }
    [JsonProperty("licenseId")]
    public Guid? licenseId { get; set; }
    [JsonProperty("field")]
    public string field { get; set; }
    [JsonProperty("oldValue")]
    public string oldValue { get; set; }
    [JsonProperty("newValue")]
    public string newValue { get; set; }
    [JsonProperty("updatedBy")]
    public string updatedBy { get; set; }
    [JsonProperty("updated")]
    public DateTime updated { get; set; }
}