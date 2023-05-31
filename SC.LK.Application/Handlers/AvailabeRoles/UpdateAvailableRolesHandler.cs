using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Handlers.AvailabeRoles;

public class UpdateAvailableRolesHandler:IRequestHandler<UpdateAvailableRolesRequest,UpdateAvailableRolesResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    public UpdateAvailableRolesHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<UpdateAvailableRolesResponse> Handle(UpdateAvailableRolesRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.GetWithInclude(x => x.Id == request.AvailableRolesId).FirstOrDefault();
        if (get != null)
        {
            if (Check(request).Result.Success)
            {
                get = new AvailableRolesEntity() 
                    { 
                        Id = request.AvailableRolesId,
                        Updated = DateTime.Now,
                        RoleName = request.RoleName,
                        RoleType = request.RoleType
                    };
                var update = _repository.Update(get);
                if (update != 0)
                    return new UpdateAvailableRolesResponse() { Success = true, AvailableRolesEntity = get };
            }

            return new UpdateAvailableRolesResponse() { Success = false, ErrorMessage = "Check your added info" };
        }

        return new UpdateAvailableRolesResponse() { Success = false, ErrorMessage = "Role not found" };
    }
    public async Task<UpdateAvailableRolesResponse> Check(UpdateAvailableRolesRequest request)
    {
        
        if (request.RoleName == null)
            return new UpdateAvailableRolesResponse(){Success = false, ErrorMessage = "RoleName can't be null"};
        if (request.RoleType == null)
            return new UpdateAvailableRolesResponse(){Success = false, ErrorMessage = "RoleType can't be null"};
        return new UpdateAvailableRolesResponse(){Success = true};
    }
}