namespace SC.LK.Application.Domains.RepositoryConfigurationService;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BusinessProcessWithOutJsonBodyView
{
    [Newtonsoft.Json.JsonProperty("businessProcessId")]
    public System.Guid BusinessProcessId { get; set; }

    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("businessProcessName")]
    public string BusinessProcessName { get; set; }

    [Newtonsoft.Json.JsonProperty("businessProcessDescription")]
    public string BusinessProcessDescription { get; set; }

    [Newtonsoft.Json.JsonProperty("isTemplate")]
    public bool IsTemplate { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationVersions")]
    public System.Collections.Generic.List<ConfigurationsBusinessProcessView> ConfigurationVersions { get; set; } = new System.Collections.Generic.List<ConfigurationsBusinessProcessView>();
}