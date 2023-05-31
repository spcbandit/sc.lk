namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class ManagedTerminalsView
{
    [Newtonsoft.Json.JsonProperty("agentId")]
    public Guid AgentId { get; set; }

    [Newtonsoft.Json.JsonProperty("managedTerminals")]
    public List<Guid> ManagedTerminals { get; set; }

}