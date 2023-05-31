namespace SC.LK.Application.Domains.RepositoryConfigurationService;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ConfigurationView
{
    [Newtonsoft.Json.JsonProperty("configurationId")]
    public System.Guid ConfigurationId { get; set; }

    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationName")]
    public string ConfigurationName { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationDescription")]
    public string ConfigurationDescription { get; set; }

    [Newtonsoft.Json.JsonProperty("updateBy")]
    public string UpdateBy { get; set; }

    [Newtonsoft.Json.JsonProperty("update")]
    public System.DateTimeOffset Update { get; set; }
}