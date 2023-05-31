namespace SC.LK.Application.Domains.CloudApiService;

public partial class LifeAgentNow
{
    /// <summary>
    /// HostName
    /// </summary>
    [Newtonsoft.Json.JsonProperty("hostName")]
    public string HostName { get; set; }

    /// <summary>
    /// IpAddress
    /// </summary>
    [Newtonsoft.Json.JsonProperty("ipAddress")]
    public System.Collections.Generic.ICollection<string> IpAddress { get; set; }

    /// <summary>
    /// HashPC
    /// </summary>
    [Newtonsoft.Json.JsonProperty("hashPC")]
    public string HashPC { get; set; }

    /// <summary>
    /// AgentId
    /// </summary>
    [Newtonsoft.Json.JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }

    /// <summary>
    /// ServiceId
    /// </summary>
    [Newtonsoft.Json.JsonProperty("serviceId")]
    public System.Guid ServiceId { get; set; }

}
