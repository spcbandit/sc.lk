using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Handlers.Finance;

public class UpdateBillingFaceByIdHandler : IRequestHandler<UpdateBillingFaceByIdRequest, UpdateBillingFaceByIdResponse>
{
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
    private readonly IMapper _mapper;
    
    /// <summary>
    ///  Обновление билинг лица
    /// </summary>
    /// <param name="repositoryBillingFace"></param>
    public UpdateBillingFaceByIdHandler(IRepository<BillingFaceEntity> repositoryBillingFace, IMapper mapper)
    {
        _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Обновление билинг лица
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateBillingFaceByIdResponse> Handle(UpdateBillingFaceByIdRequest request, CancellationToken cancellationToken)
    {
        var billingFace = _repositoryBillingFace.FindById(request.BillingFaceId);

        if (billingFace == null)
        {
            return new UpdateBillingFaceByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateBillingFace};
        }
        billingFace.Name = request.Name;
        billingFace.INN = request.INN;
        billingFace.KPP = request.KPP;
        var billingFaceDto = _mapper.Map<BillingFaceDto>(billingFace);
        var res = _repositoryBillingFace.Update(billingFace);
        if(res !=0)
            return new UpdateBillingFaceByIdResponse() {Success = true, BillingFace = billingFaceDto}; 
        else
            return new UpdateBillingFaceByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateBillingFace};
    }
    
}