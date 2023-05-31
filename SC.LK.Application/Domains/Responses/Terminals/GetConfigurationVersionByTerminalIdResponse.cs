using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Terminals;

public class GetConfigurationVersionByTerminalIdResponse : BaseResponse
{
    public ConfigurationVersionSignViewDto Configuration { get; set; }
}