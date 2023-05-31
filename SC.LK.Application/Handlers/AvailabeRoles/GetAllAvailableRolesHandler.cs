using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.AvailableRoles;
using SC.LK.Application.Domains.Responses.AvailableRole;

namespace SC.LK.Application.Handlers.AvailabeRoles;

public class GetAllAvailableRolesHandler:IRequestHandler<GetAllAvailableRolesRequest, GetAllAvailableRolesResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    public GetAllAvailableRolesHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllAvailableRolesResponse> Handle(GetAllAvailableRolesRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get().ToList();
        if (get.Any())
        {
            return new GetAllAvailableRolesResponse() { Success = true, ListAvailableRoles = get };
        }

        return new GetAllAvailableRolesResponse() { Success = false, ErrorMessage = "Error" };
    }
}