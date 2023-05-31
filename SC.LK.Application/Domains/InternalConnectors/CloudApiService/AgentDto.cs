namespace SC.LK.Application.Domains.CloudApiService;

public partial class AgentDto
{
    [Newtonsoft.Json.JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }

    [Newtonsoft.Json.JsonProperty("createdAgent")]
    public System.DateTimeOffset CreatedAgent { get; set; }

    [Newtonsoft.Json.JsonProperty("shopId")]
    public System.Guid? ShopId { get; set; }

    [Newtonsoft.Json.JsonProperty("serviceId")]
    public System.Guid ServiceId { get; set; }

    [Newtonsoft.Json.JsonProperty("iPs")]
    public System.Collections.Generic.ICollection<string> IPs { get; set; }

    [Newtonsoft.Json.JsonProperty("lastVisableAgent")]
    public System.DateTimeOffset LastVisableAgent { get; set; }

}

