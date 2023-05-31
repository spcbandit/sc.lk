using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Profile;

public class GetUserInfoResponse : BaseResponse
{
    /// <summary>
    /// UserInfo
    /// </summary>
    public UserInfoDto UserInfo { get; set; }
    
    public List<BaseContractorDto> Contractors { get; set; }
}