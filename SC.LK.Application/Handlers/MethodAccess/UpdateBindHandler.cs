using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class UpdateBindHandler:IRequestHandler<UpdateBindRequest,UpdateBindResponse>
{
    private readonly IRepository<MethodWithRoles> _repository;
    private readonly IRepository<AvailableRolesEntity> _repositoryRoles;
    public UpdateBindHandler(IRepository<MethodWithRoles> repository, IRepository<AvailableRolesEntity> repositoryRoles)
    {
        _repository = repository;
        _repositoryRoles = repositoryRoles;
    }

    public async Task<UpdateBindResponse> Handle(UpdateBindRequest request, CancellationToken cancellationToken)
    {
        var getRole = _repositoryRoles.Get(x => x.RoleName == request.NewRole).FirstOrDefault();
        var get = _repository.Get(x=>x.MethodAccessTypesEntitiesId == request.MethodId).FirstOrDefault();
        if (get != null)
        {
            var updEntity = new MethodWithRoles()
            {
                Id = get.Id, Updated = DateTime.Now, AvailableRoleId = getRole.Id,
                MethodAccessTypesEntitiesId = get.MethodAccessTypesEntitiesId
            };
            var update = _repository.Update(updEntity);
            return new UpdateBindResponse() { Success = true };
        }
        return new UpdateBindResponse() { Success = false };
    }
}