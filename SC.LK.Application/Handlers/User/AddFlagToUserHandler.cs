using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Handlers.Profile;

public class AddFlagToUserHandler:IRequestHandler<AddFlagToUserRequest,AddFlagToUserResponse>
{
    private readonly IRepository<UserEntity> _repository;
    public AddFlagToUserHandler(IRepository<UserEntity> repository)
    {
        _repository = repository;
    }

    public async Task<AddFlagToUserResponse> Handle(AddFlagToUserRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get(x => x.Id == request.UserId).FirstOrDefault();
        if (get != null)
        {
            get.IsSuper = true;
            var upd = _repository.Update(get);
            return new AddFlagToUserResponse() {Success = true};
        }
        return new AddFlagToUserResponse() {Success = false};
    }
}