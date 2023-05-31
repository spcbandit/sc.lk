using MediatR;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Domains.Requests.AvailableRoles;

public class DeleteAvailableRoleRequest:IRequest<DeleteAvailableRoleResponse>
{
    public Guid Id { get; set; }
}