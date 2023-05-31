using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Responses.User;

public class CreateUserResponse : BaseResponse
{
    /// <summary>
    /// User
    /// </summary>
    public BaseUserDto User { get; set; }
}