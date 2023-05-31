namespace SC.LK.Application.Domains.CloudApiService;


[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
public partial class ScannerDto
{
    /// <summary>
    /// ScannerId
    /// </summary>
    [Newtonsoft.Json.JsonProperty("scannerId")]
    public System.Guid ScannerId { get; set; }

    /// <summary>
    /// AgentId
    /// </summary>
    [Newtonsoft.Json.JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }
    
    /// <summary>
    /// Deviceid
    /// </summary>
    public string Deviceid { get; set; }

    /// <summary>
    /// AddedScanner
    /// </summary>
    public DateTime AddedScanner { get; set; }

}
