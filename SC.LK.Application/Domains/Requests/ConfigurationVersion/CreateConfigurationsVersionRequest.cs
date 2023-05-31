using MediatR;
using Newtonsoft.Json;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class CreateConfigurationsVersionRequest : IRequest<CreateConfigurationsVersionResponse>
{
    /// <summary>
    /// ConfigurationId
    /// </summary>
    [JsonProperty("ConfigurationId")]
    public Guid ConfigurationId { get; set; }
    
    public bool IsActive { get; set; }

    /// <summary>
    /// JsonBody
    /// </summary>
    [JsonProperty("BusinessProceses")]
    public List<CreateConfigurationsBusinessProcess> BusinessProceses { get; set; }
    
}

public class CreateConfigurationsBusinessProcess
{
    public Guid BusinessProcessId { get; set; }
    
    public int BusinessProcessNumber { get; set; }
}