using System.Text.Json;
using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class ItemForSaleResponse
{
    [JsonProperty("itemForSaleId")]
    public Guid? itemForSaleId { get; set; }
    [JsonProperty("priceListId")]
    public Guid? priceListId { get; set; }
    [JsonProperty("entityType")]
    public int entityType { get; set; }
    [JsonProperty("itemContent")]
    public string itemContent { get; set; }
    [JsonProperty("itemHyperlink")]
    public string itemHyperlink { get; set; }
    [JsonProperty("itemName")]
    public string itemName { get; set; }
    [JsonProperty("itemDescription")]
    public string itemDescription { get; set; }
    [JsonProperty("documentationsHyperlink")]
    public string documentationsHyperlink { get; set; }
    [JsonProperty("updatedBy")]
    public string updatedBy { get; set; }
    [JsonProperty("updated")]
    public DateTime updated { get; set; }
    [JsonProperty("priceList")]
    public PriceList priceList { get; set; }
}