using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.MethodAccess;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Handlers.MethodAccess;

public class GetAllMethodsHandler:IRequestHandler<GetAllMethodsRequest,GetAllMethodsResponse>
{
    private readonly IRepository<MethodAccessTypeEntity> _repository;

    public GetAllMethodsHandler(IRepository<MethodAccessTypeEntity> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllMethodsResponse> Handle(GetAllMethodsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var get = _repository.Get().ToList();
            if (get != null)
            {
                return new GetAllMethodsResponse() { Success = true , MethodAccess = get};
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new GetAllMethodsResponse() { Success = false , ErrorMessage = e.Message};
        }
        return new GetAllMethodsResponse() { Success = false };
        
    }
}