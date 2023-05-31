using System.Text.Json;
using Newtonsoft.Json;

namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class DistributivesView
{
    [JsonProperty("version")]
    public string Version { get; set; }
    [JsonProperty("distributiveId")]
    public Guid DistributiveId { get; set; }
}