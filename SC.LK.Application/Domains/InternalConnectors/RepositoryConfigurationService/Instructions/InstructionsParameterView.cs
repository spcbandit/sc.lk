using Newtonsoft.Json;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class InstructionsParameterView
{
    [JsonProperty("parameterId")]
    public Guid ParameterId { get; set; }

    [JsonProperty("instructionId")]
    public Guid InstructionId { get; set; }

    [JsonProperty("idx")]
    public int Idx { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("parentId")]
    public Guid ParentId { get; set; }

    [JsonProperty("parametersValues")]
    public List<InstructionsParametersValueView> ParametersValues { get; set; }
}