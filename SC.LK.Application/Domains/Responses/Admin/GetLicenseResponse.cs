using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Admin;

public class GetLicenseResponse : BaseResponse
{
    public LicenseViewDto LicenseViewDto { get; set; }
}