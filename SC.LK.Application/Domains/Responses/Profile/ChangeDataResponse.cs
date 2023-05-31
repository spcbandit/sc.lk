using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Profile;

public class ChangeDataResponse : BaseResponse
{
    /// <summary>
    /// UserEntity
    /// </summary>
    public UserDto? UserEntity { get; set; }
}