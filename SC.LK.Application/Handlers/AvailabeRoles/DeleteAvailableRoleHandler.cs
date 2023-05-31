using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Handlers.AvailabeRoles;

public class DeleteAvailableRoleHandler:IRequestHandler<DeleteAvailableRoleRequest, DeleteAvailableRoleResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    public DeleteAvailableRoleHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<DeleteAvailableRoleResponse> Handle(DeleteAvailableRoleRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.GetWithInclude(x => x.Id == request.Id).FirstOrDefault();
        if (get != null)
        {
            var delete = _repository.Remove(get);
            return new DeleteAvailableRoleResponse(){Success = true};
        }

        return new DeleteAvailableRoleResponse() { Success = false, ErrorMessage = "Roles not found" };
    }
}