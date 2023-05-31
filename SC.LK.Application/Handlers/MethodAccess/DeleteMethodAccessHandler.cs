using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class DeleteMethodAccessHandler:IRequestHandler<DeleteMethodAccessRequest,DeleteMethodAccessResponse>
{
    private readonly IRepository<MethodAccessTypeEntity> _repository;
    public DeleteMethodAccessHandler(IRepository<MethodAccessTypeEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<DeleteMethodAccessResponse> Handle(DeleteMethodAccessRequest request, CancellationToken cancellationToken)
    {
        var res = _repository.GetWithInclude(x => x.Id == request.Id).FirstOrDefault();
        if (res != null)
        {
            var delete = _repository.Remove(res);
            return new DeleteMethodAccessResponse() { Success = true };
        }

        return new DeleteMethodAccessResponse() { Success = false };
    }
}