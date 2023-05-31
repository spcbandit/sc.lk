namespace SC.LK.Application.Domains.RepositoryConfigurationService;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ConfigurationsBusinessProcessView
{
    [Newtonsoft.Json.JsonProperty("id")]
    public System.Guid Id { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationVersionId")]
    public System.Guid ConfigurationVersionId { get; set; }

    [Newtonsoft.Json.JsonProperty("businessProcessId")]
    public System.Guid BusinessProcessId { get; set; }

    [Newtonsoft.Json.JsonProperty("orderNumber")]
    public int OrderNumber { get; set; }


}