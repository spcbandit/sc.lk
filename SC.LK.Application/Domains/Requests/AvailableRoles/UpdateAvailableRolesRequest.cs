using MediatR;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Domains.Requests.AvailableRoles;

public class UpdateAvailableRolesRequest:IRequest<UpdateAvailableRolesResponse>
{
    public Guid AvailableRolesId { get; set; }
    public string RoleName { get; set; }
    public decimal RoleType { get; set; }

}