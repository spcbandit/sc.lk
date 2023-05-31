using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class PriceListHeader
{
    [JsonProperty("priceListHeaderId")]
    public string priceListHeaderId { get; set; }

    [JsonProperty("description")]
    public string description { get; set; }

    [JsonProperty("provider")]
    public string provider { get; set; }

    [JsonProperty("updatedBy")]
    public string updatedBy { get; set; }

    [JsonProperty("updated")]
    public DateTime updated { get; set; }

    [JsonProperty("priceListTargetKontragents")]
    public List<PriceListTargetKontragent> priceListTargetKontragents { get; set; }

    [JsonProperty("priceListBodyes")]
    public List<PriceListBodyes> priceListBodyes { get; set; }
}