using MediatR;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class DeleteRolesFromMethodRequest:IRequest<DeleteRolesFromMethodResponse>
{
    public Guid MethodId { get; set; }
    public Guid AvailableRoleId { get; set; }
}