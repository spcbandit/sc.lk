namespace SC.LK.Application.Domains.InternalConnectors.BillingService;

public class VersionResponse
{
    [Newtonsoft.Json.JsonProperty("version")]
    public string Version { get; set; }
}