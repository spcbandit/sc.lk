using MediatR;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class UpdateBindRequest:IRequest<UpdateBindResponse>
{
    public Guid MethodId { get; set; }
    public string NewRole { get; set; }
}