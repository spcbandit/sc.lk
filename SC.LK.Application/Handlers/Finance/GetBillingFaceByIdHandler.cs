using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Handlers.Finance;

public class GetBillingFaceByIdHandler : IRequestHandler<GetBillingFaceByIdRequest, GetBillingFaceByIdResponse>
{
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
    private readonly IMapper _mapper;
    //private readonly IMapper _mapper;   
    
    /// <summary>
    /// Получение билинг лица по ID
    /// </summary>
    /// <param name="repositoryBillingFace"></param>
    public GetBillingFaceByIdHandler(IRepository<BillingFaceEntity> repositoryBillingFace, IMapper mapper)
    {
        _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Получение билинг лица по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetBillingFaceByIdResponse> Handle(GetBillingFaceByIdRequest request, CancellationToken cancellationToken)
    {
        var billingFace = _repositoryBillingFace.FindById(request.BillingFaceId);
        var billingFaceDto = _mapper.Map<BillingFaceDto>(billingFace);
        if (billingFace != null)
            return new GetBillingFaceByIdResponse() {Success = true, BillingFace = billingFaceDto};
        else
            return new GetBillingFaceByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetBillingFace};
    }
}