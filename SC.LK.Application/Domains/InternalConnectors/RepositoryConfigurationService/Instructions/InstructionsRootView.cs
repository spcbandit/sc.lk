using Newtonsoft.Json;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;

public class InstructionsRootView
{
    [JsonProperty("instructionId")]
    public Guid InstructionId { get; set; }

    [JsonProperty("idx")]
    public int Idx { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("inputData")]
    public int InputData { get; set; }

    [JsonProperty("group")]
    public string Group { get; set; }

    [JsonProperty("events")]
    public List<InstructionsEventView> Events { get; set; }

    [JsonProperty("parameters")]
    public List<InstructionsParameterView> Parameters { get; set; }

    [JsonProperty("setting")]
    public InstructionsSettingView Setting { get; set; }
}