namespace SC.LK.Application.Domains.CloudApiService;

public partial class AgentTerminalIdVersionView
{
    [Newtonsoft.Json.JsonProperty("terminalId")]
    public System.Guid? TerminalId { get; set; }

    [Newtonsoft.Json.JsonProperty("version")]
    public int Version { get; set; }

}