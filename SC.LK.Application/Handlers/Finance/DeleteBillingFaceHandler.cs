using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Handlers.Finance;

public class DeleteBillingFaceHandler : IRequestHandler<DeleteBillingFaceRequest, DeleteBillingFaceResponse>
{
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
    //private readonly IMapper _mapper;   
    
    /// <summary>
    /// удаление билинг лица
    /// </summary>
    /// <param name="repositoryBillingFace"></param>
    public DeleteBillingFaceHandler(IRepository<BillingFaceEntity> repositoryBillingFace)
    {
        _repositoryBillingFace = repositoryBillingFace?? throw new ArgumentException(nameof(repositoryBillingFace));
    }

    /// <summary>
    /// удаление билинг лица
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteBillingFaceResponse> Handle(DeleteBillingFaceRequest request, CancellationToken cancellationToken)
    {
        var billingFace = _repositoryBillingFace.FindById(request.BillingFaceId);
        
        _repositoryBillingFace.Remove(billingFace);
        
        if (billingFace != null)
            return new DeleteBillingFaceResponse() {Success = true};
        else
            return new DeleteBillingFaceResponse() {Success = false, ErrorMessage = MessageResource.FailedDeleteBillingFace};
    }
}