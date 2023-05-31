using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Handlers.Profile;

public class DeleteUserHandler: IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="repositoryUser"></param>
    public DeleteUserHandler(IRepository<UserEntity> repositoryUser)
    {
        _repositoryUser = repositoryUser ?? 
                          throw new ArgumentException(nameof(repositoryUser));
    }

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryUser.FindById(request.UserId);
        user.IsDelete = true;
        var res = _repositoryUser.Update(user);
        if (res == 1)
            return new DeleteUserResponse()
            {
                Success = true,
                Id = user.Id
            };
        else
            return new DeleteUserResponse()
            {
                Success = false, 
                ErrorMessage = MessageResource.FailedDeleteUser
            };
    }
}