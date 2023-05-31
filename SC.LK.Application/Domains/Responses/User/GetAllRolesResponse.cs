using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.User;

public class GetAllRolesResponse : BaseResponse
{
    public List<AvailableRolesEntity> AvailableRoles { get; set; }
}