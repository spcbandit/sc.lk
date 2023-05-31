using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Handlers.Profile;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    private readonly IRepository<AvailableRolesEntity> _repository;
    public GetAllRolesHandler(IRepository<AvailableRolesEntity> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get().ToList();
        if (get.Any())
        {
            return new GetAllRolesResponse()
            {
                Success = true, AvailableRoles = get
            };
        }

        return new GetAllRolesResponse() { Success = false };

    }
}