using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class BindMethodAndRolesHandler:IRequestHandler<BindMethodAndRolesRequest,BindMethodAndRolesResponse>
{
    private readonly IRepository<MethodWithRoles> _repository;

    public BindMethodAndRolesHandler(IRepository<MethodWithRoles> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<BindMethodAndRolesResponse> Handle(BindMethodAndRolesRequest request, CancellationToken cancellationToken)
    {
        if (request.Admin !=0)
        {
            var create = _repository.Create(new MethodWithRoles()
            {
                Id = Guid.NewGuid(), Updated = DateTime.Now, AvailableRoleId = new Guid("08daadc6-a774-4b18-86a3-eed249385cb7"), MethodAccessTypesEntitiesId = request.MethodAccessTypeId
            });
        }
        if (request.Manager !=0)
        {
            var create = _repository.Create(new MethodWithRoles()
            {
                Id = Guid.NewGuid(), Updated = DateTime.Now, AvailableRoleId = new Guid("08daadc7-20f8-411b-8682-224d937f495c"), MethodAccessTypesEntitiesId = request.MethodAccessTypeId
            });
        }
        if (request.Support !=0)
        {
            var create = _repository.Create(new MethodWithRoles()
            {
                Id = Guid.NewGuid(), Updated = DateTime.Now, AvailableRoleId = new Guid("08dab19c-a288-461a-8a24-8223cb7e6e92"), MethodAccessTypesEntitiesId = request.MethodAccessTypeId
            });
        }

        return new BindMethodAndRolesResponse() { Success = true };
    }
}