using Newtonsoft.Json;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class AgentsView
{
    [JsonProperty("kontragentId")]
    public Guid? KontragentId { get; set; }
    [JsonProperty("divisionId")]
    public Guid? DivisionId { get; set; }
    [JsonProperty("agents")] 
    public List<AgentView> Agents { get; set; } = new List<AgentView>();
}