using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class AddNewAccessMethodHandler:IRequestHandler<AddNewMethodAccessRequest, AddNewMethodAccessResponse>
{
    private readonly IRepository<MethodAccessTypeEntity> _repository;
    
    public AddNewAccessMethodHandler(IRepository<MethodAccessTypeEntity> repository,IRepository<MethodWithRoles> repositoryAv)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        
    }

    public async Task<AddNewMethodAccessResponse> Handle(AddNewMethodAccessRequest request, CancellationToken cancellationToken)
    {
        if (request.MethodName!=String.Empty)
        {
            var id = new Guid();
            var res = _repository.Create(new MethodAccessTypeEntity()
                {
                    Id = id,
                    Updated = DateTime.Now,
                    MethodName = request.MethodName,
                }
            );
            if (res != 0)
            {
                return new AddNewMethodAccessResponse() { Success = true, NewMethodId = id};
            }

            return new AddNewMethodAccessResponse() { Success = false};
        }
        return new AddNewMethodAccessResponse(){Success = false, ErrorMessage = "Name can't be empty"};
    }
}