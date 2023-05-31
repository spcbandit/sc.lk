namespace SC.LK.Application.Domains.SigningEncryptionService;

public class ProblemDetails
{
    [Newtonsoft.Json.JsonProperty("type")]
    public string Type { get; set; }

    [Newtonsoft.Json.JsonProperty("title")]
    public string Title { get; set; }

    [Newtonsoft.Json.JsonProperty("status")]
    public int? Status { get; set; }

    [Newtonsoft.Json.JsonProperty("detail")]
    public string Detail { get; set; }

    [Newtonsoft.Json.JsonProperty("instance")]
    public string Instance { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}