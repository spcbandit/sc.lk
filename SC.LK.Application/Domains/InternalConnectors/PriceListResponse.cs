using Newtonsoft.Json;
using SC.LK.Application.Domains.InternalConnectors.BillingService;

namespace SC.LK.Application.Domains.InternalConnectors;

public class PriceListResponse
{
    [JsonProperty("priceListId")]
    public string priceListId { get; set; }
    [JsonProperty("licenseId")]
    public Guid licenseId { get; set; }
    [JsonProperty("entityId")]
    public Guid entityId { get; set; }
    [JsonProperty("entityType")]
    public int entityType { get; set; }
    [JsonProperty("entityName")]
    public string entityName { get; set; }
    [JsonProperty("entityOwner")]
    public string entityOwner { get; set; }
    [JsonProperty("price")]
    public int price { get; set; }
    [JsonProperty("updatedBy")]
    public string updatedBy { get; set; }
    [JsonProperty("updated")]
    public DateTime updated { get; set; }
    [JsonProperty("priceListBodyes")]
    public List<PriceListBodyes> priceListBodyes { get; set; }
    [JsonProperty("itemForSale")]
    public ItemForSaleResponse itemForSale { get; set; }
    [JsonProperty("license")]
    public License license { get; set; }
}