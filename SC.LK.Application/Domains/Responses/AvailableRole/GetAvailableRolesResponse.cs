using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.AvailableRole;

public class GetAvailableRolesResponse:BaseResponse
{
    public AvailableRolesEntity AvailableRolesEntity { get; set; }
}