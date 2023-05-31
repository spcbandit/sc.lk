using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.ConfigurationVersion;

public class GetConfigurationVersionResponse : BaseResponse
{
    public ConfigurationVersionViewDto ConfigurationVersionViewDto { get; set; }
}