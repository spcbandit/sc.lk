using MediatR;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Domains.Requests.AvailableRoles;

public class AddAvailableRoleRequest:IRequest<AddAvailableRoleResponse>
{
    public string RoleName { get; set; }
    public decimal RoleType { get; set; }

}