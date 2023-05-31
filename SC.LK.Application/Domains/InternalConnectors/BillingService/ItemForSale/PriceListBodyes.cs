using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class PriceListBodyes
{
    [JsonProperty("priceListBodyId")]
    public Guid priceListBodyId { get; set; }
    [JsonProperty("priceListHeaderId")]
    public Guid priceListHeaderId { get; set; }
    [JsonProperty("priceListId")]
    public Guid priceListId { get; set; }
    [JsonProperty("discount")]
    public int discount { get; set; }
    [JsonProperty("validFrom")]
    public DateTime validFrom { get; set; }
    [JsonProperty("rebateQty")]
    public int rebateQty { get; set; }
    [JsonProperty("rebateValue")]
    public int rebateValue { get; set; }
}