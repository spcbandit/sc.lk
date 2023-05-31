using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.AvailableRole;

public class GetAllAvailableRolesResponse:BaseResponse
{
    public List<AvailableRolesEntity> ListAvailableRoles { get; set; }
}