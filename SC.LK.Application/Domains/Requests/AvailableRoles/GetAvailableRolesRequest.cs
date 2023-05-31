using MediatR;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Domains.Requests.AvailableRoles;

public class GetAvailableRolesRequest:IRequest<GetAvailableRolesResponse>
{
    public Guid AvailableRoleId { get; set; }
}