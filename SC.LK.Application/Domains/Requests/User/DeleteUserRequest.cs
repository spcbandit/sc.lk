using MediatR;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Requests.User;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
}