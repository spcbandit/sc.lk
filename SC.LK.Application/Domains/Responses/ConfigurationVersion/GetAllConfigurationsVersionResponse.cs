using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.ConfigurationVersion;

public class GetAllConfigurationsVersionResponse : BaseResponse
{
    public List<ConfigurationVersionViewDto> ConfigurationVersions { get; set; }
}