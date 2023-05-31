namespace SC.LK.Application.Domains.SigningEncryptionService;

public class KontragentCertificateView
{
    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid? KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("signPublic")]
    public string SignPublic { get; set; }
}