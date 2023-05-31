namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class ConfigurationVersionSignView
{
    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("terminalId")]
    public System.Guid TerminalId { get; set; }

    [Newtonsoft.Json.JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationVersion")]
    public string ConfigurationVersion { get; set; }
}