namespace SC.LK.Application.Domains.SigningEncryptionService;

public class SignedKontragentFileView
{
    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid? KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("jsonFile")]
    public string JsonFile { get; set; }

}