using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class DeleteRolesFromMethodHandler:IRequestHandler<DeleteRolesFromMethodRequest, DeleteRolesFromMethodResponse>
{
    private readonly IRepository<MethodWithRoles> _repository;
    public DeleteRolesFromMethodHandler(IRepository<MethodWithRoles> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<DeleteRolesFromMethodResponse> Handle(DeleteRolesFromMethodRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.GetWithInclude(
                x => x.AvailableRoleId == request.AvailableRoleId && x.MethodAccessTypesEntitiesId == request.MethodId)
            .FirstOrDefault();
        if (get != null)
        {
            var delete = _repository.Remove(get);
            if (delete != 0)
            {
                return new DeleteRolesFromMethodResponse() { Success = true };
            }
            return new DeleteRolesFromMethodResponse() { Success = false };
        }
        return new DeleteRolesFromMethodResponse() { Success = false };
    }
}