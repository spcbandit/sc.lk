using MediatR;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class BindMethodAndRolesRequest:IRequest<BindMethodAndRolesResponse>
{
    public int Admin { get; set; }
    public int Manager { get; set; }
    public int Support { get; set; }
    public Guid MethodAccessTypeId { get; set; }
}