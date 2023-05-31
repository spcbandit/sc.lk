using Newtonsoft.Json;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class InstructionsSettingView
{
    [JsonProperty("settingsId")]
    public Guid SettingsId { get; set; }

    [JsonProperty("instructionId")]
    public Guid InstructionId { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("instruction")]
    public string Instruction { get; set; }
}