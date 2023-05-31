namespace SC.LK.Application.Domains.CloudApiService;


[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
public partial class ScannerDescription
{
    /// <summary>
    /// ScannerId
    /// </summary>
    [Newtonsoft.Json.JsonProperty("scannerId")]
    public string ScannerId { get; set; }
    
    /// <summary>
    /// Config
    /// </summary>
    [Newtonsoft.Json.JsonProperty("config")]
    public string Config { get; set; }

    /// <summary>
    /// DateTimeOffset
    /// </summary>
    [Newtonsoft.Json.JsonProperty("added")]
    public System.DateTimeOffset Added { get; set; }

    /// <summary>
    /// Version
    /// </summary>
    [Newtonsoft.Json.JsonProperty("version")]
    public int Version { get; set; }

}
