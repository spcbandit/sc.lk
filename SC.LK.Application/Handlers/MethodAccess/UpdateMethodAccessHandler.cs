using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class UpdateMethodAccessHandler:IRequestHandler<UpdateMethodAccessRequest, UpdateMethodAccessResponse>
{
    private readonly IRepository<MethodAccessTypeEntity> _repository;
    public UpdateMethodAccessHandler(IRepository<MethodAccessTypeEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<UpdateMethodAccessResponse> Handle(UpdateMethodAccessRequest request, CancellationToken cancellationToken)
    {
        var res = _repository.GetWithInclude(x => x.Id == request.MethodAccessTypeEntity.Id).FirstOrDefault();
        if (res != null)
        {
            res = new MethodAccessTypeEntity()
            {
                Id = request.MethodAccessTypeEntity.Id,
                Updated = DateTime.Now,
                MethodName = request.MethodAccessTypeEntity.MethodName
            };
            var update = _repository.Update(res);
            if(update !=0)
                return new UpdateMethodAccessResponse() { Success = true };
        }
        return new UpdateMethodAccessResponse() { Success = false };
    }
}