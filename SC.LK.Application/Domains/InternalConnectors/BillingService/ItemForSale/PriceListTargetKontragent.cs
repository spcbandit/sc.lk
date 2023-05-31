using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class PriceListTargetKontragent
{
    [JsonProperty("priceListTargetKontragentId")]
    public string priceListTargetKontragentId { get; set; }

    [JsonProperty("priceListHeaderId")]
    public string priceListHeaderId { get; set; }

    [JsonProperty("kontragentId")]
    public string kontragentId { get; set; }
}