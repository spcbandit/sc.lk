using MediatR;
using Newtonsoft.Json;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Domains.Requests.ConfigurationVersion;

public class UpdateConfigurationVersionRequest : IRequest<UpdateConfigurationVersionResponse>
{
    /// <summary>
    /// ConfigurationId
    /// </summary>
    [JsonProperty("ConfigurationId")]
    public Guid ConfigurationId { get; set; }
    
    [JsonProperty("ConfigurationVersionId")]
    public Guid ConfigurationVersionId { get; set; }
    public bool IsActive { get; set; }

    /// <summary>
    /// JsonBody
    /// </summary>
    [JsonProperty("BusinessProceses")]
    public List<BusinessProcess> BusinessProceses { get; set; }
    
}

public class BusinessProcess
{
    public Guid BusinessProcessId { get; set; }
    
    public int BusinessProcessNumber { get; set; }
}