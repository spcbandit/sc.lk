using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.TerminalLicense;

public class GetLicencesByKontragentResponse : BaseResponse
{
    public List<LicenseViewDto> LicenseView { get; set; }
}