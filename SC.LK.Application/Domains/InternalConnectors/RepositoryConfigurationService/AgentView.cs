using Newtonsoft.Json;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class AgentView
{
    [JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }

    [JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [JsonProperty("divisionId")]
    public System.Guid DivisionId { get; set; }

    [JsonProperty("hostName")]
    public string HostName { get; set; }

    [JsonProperty("hostAddress")]
    public string HostAddress { get; set; }

    [JsonProperty("hostFingerprint")]
    public string HostFingerprint { get; set; }

    [JsonProperty("currentVersion")]
    public string CurrentVersion { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }

    [JsonProperty("updateBy")]
    public string UpdateBy { get; set; }

    [JsonProperty("update")]
    public System.DateTimeOffset Update { get; set; }

    [JsonProperty("distributiveId")]
    public System.Guid DistributiveId { get; set; }
}