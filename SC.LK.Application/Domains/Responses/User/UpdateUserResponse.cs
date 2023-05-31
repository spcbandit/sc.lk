using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.User;

public class UpdateUserResponse : BaseResponse
{
    /// <summary>
    /// User
    /// </summary>
    public BaseUserDto User {get; set;}
}