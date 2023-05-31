using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.User;

public class GetAllUsersResponse : BaseResponse
{
    /// <summary>
    /// Users
    /// </summary>
    public List<BaseUserDto> Users { get; set; }
}