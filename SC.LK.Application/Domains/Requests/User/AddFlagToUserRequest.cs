using MediatR;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Requests.User;

public class AddFlagToUserRequest:IRequest<AddFlagToUserResponse>
{
    public Guid UserId { get; set; }
    public bool IsSuper { get; set; }
}