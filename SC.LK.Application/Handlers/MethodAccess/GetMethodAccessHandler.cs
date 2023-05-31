using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class GetMethodAccessHandler:IRequestHandler<GetMethodAccessRequest,GetMethodAccessResponse>
{
    private readonly IRepository<MethodAccessTypeEntity> _repository;
    public GetMethodAccessHandler(IRepository<MethodAccessTypeEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<GetMethodAccessResponse> Handle(GetMethodAccessRequest request,
        CancellationToken cancellationToken)
    {
        var get = _repository.GetWithInclude(x => x.Id == request.Id).FirstOrDefault();
        if (get != null)
        {
            return new GetMethodAccessResponse() { Success = true , MethodAccessTypeEntity = get};
        }

        return new GetMethodAccessResponse() { Success = false };
    }
}