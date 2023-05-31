namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class AgentsViewExtended
{
    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("divisionId")]
    public System.Guid DivisionId { get; set; }

    [Newtonsoft.Json.JsonProperty("agents")]
    public System.Collections.Generic.List<Guid> Agents { get; set; }

}