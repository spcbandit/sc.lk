using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Configurations;

public class GetAllConfigurationsResponse : BaseResponse
{
    /// <summary>
    /// DtoResult
    /// </summary>
    public List<DtoResult> DtoResult { get; set; }
}

public class DtoResult
{
    public Guid IdConfig { get; set; }
    public Guid IdVersion { get; set; }
    public string NameConfig { get; set; }
    public string Version { get; set; }
}