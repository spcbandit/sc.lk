namespace SC.LK.Application.Domains.SigningEncryptionService;

public class ClientView
{
    [Newtonsoft.Json.JsonProperty("idClient")]
    public System.Guid IdClient { get; set; }

    [Newtonsoft.Json.JsonProperty("signPublic")]
    public string SignPublic { get; set; }
}