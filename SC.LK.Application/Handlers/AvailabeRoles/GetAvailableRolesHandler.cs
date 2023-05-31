using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Handlers.AvailabeRoles;

public class GetAvailableRolesHandler:IRequestHandler<GetAvailableRolesRequest,GetAvailableRolesResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    public GetAvailableRolesHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<GetAvailableRolesResponse> Handle(GetAvailableRolesRequest request, CancellationToken cancellationToken)
    {
        if (request.AvailableRoleId != Guid.Empty)
        {
            var get = _repository.FindById(request.AvailableRoleId);
            return new GetAvailableRolesResponse() { Success = true, AvailableRolesEntity = get };
        }

        return new GetAvailableRolesResponse() { Success = false };

    }
}