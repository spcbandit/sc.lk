using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.AvailableRole;

public class UpdateAvailableRolesResponse:BaseResponse
{
    public AvailableRolesEntity AvailableRolesEntity { get; set; }
}