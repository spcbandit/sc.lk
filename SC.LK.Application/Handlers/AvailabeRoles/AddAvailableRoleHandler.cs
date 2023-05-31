using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Handlers.AvailabeRoles;

public class AddAvailableRoleHandler:IRequestHandler<AddAvailableRoleRequest,AddAvailableRoleResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    
    public AddAvailableRoleHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<AddAvailableRoleResponse> Handle(AddAvailableRoleRequest request, CancellationToken cancellationToken)
    {
        if (Check(request).Result.Success)
        {
            var create =  _repository.Create(
                new AvailableRolesEntity()
                {
                    Id = new Guid(),
                    Updated = DateTime.Now,
                    RoleName = request.RoleName,
                    RoleType = request.RoleType,
                });
            if (create != 0)
                return new AddAvailableRoleResponse() { Success = true };
        }
        return new AddAvailableRoleResponse() { Success = false };
    }

    public async Task<AddAvailableRoleResponse> Check(AddAvailableRoleRequest request)
    {
        
        if (request.RoleName == null)
            return new AddAvailableRoleResponse(){Success = false, ErrorMessage = "RoleName can't be null"};
        if (request.RoleType == null)
            return new AddAvailableRoleResponse(){Success = false, ErrorMessage = "RoleType can't be null"};
        return new AddAvailableRoleResponse(){Success = true};
    }
}