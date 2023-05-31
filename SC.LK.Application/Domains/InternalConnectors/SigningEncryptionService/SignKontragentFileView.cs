namespace SC.LK.Application.Domains.SigningEncryptionService;

public class SignKontragentFileView
{
    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid? KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("signedjsonFile")]
    public string SignedjsonFile { get; set; }

}