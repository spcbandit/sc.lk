using Newtonsoft.Json;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class InstructionsEventView
{
    [JsonProperty("eventsId")]
    public Guid EventsId { get; set; }

    [JsonProperty("instructionId")]
    public Guid InstructionId { get; set; }

    [JsonProperty("eventName")]
    public int EventName { get; set; }

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("outputData")]
    public int OutputData { get; set; }
}