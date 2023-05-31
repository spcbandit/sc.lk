using Newtonsoft.Json;

namespace SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;

public class InstructionsParametersValueView
{
    [JsonProperty("valueId")]
    public Guid ValueId { get; set; }

    [JsonProperty("parameterId")]
    public Guid ParameterId { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("parentId")]
    public Guid ParentId { get; set; }
}