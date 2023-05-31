namespace SC.LK.Application.Domains.CloudApiService;

public partial class LocalCache
{
    [Newtonsoft.Json.JsonProperty("scannerId")]
    public string ScannerId { get; set; }

    [Newtonsoft.Json.JsonProperty("version")]
    public int Version { get; set; }

}