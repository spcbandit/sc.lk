using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Handlers.Finance;

public class CreateBillingFaceHandler : IRequestHandler<CreateBillingFaceRequest, CreateBillingFaceResponse>
{
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
    private readonly IMapper _mapper;   
    
    /// <summary>
    /// Создание Билинг лица
    /// </summary>
    /// <param name="repositoryBillingFace"></param>
    public CreateBillingFaceHandler(IRepository<BillingFaceEntity> repositoryBillingFace, IMapper mapper)
    {
        _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Создание Билинг лица
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateBillingFaceResponse> Handle(CreateBillingFaceRequest request, CancellationToken cancellationToken)
    {
        var billingFace = new BillingFaceEntity
        {
            Name = request.Name,
            INN = request.INN,
            KPP = request.KPP,
            PaymentSystem = new PaymentSystemEntity(),
            СontractorId = request.ContractorId
        };
        var res = _repositoryBillingFace.Create(billingFace);
        if (res != 0)
        {
            var billingFaceDto = _mapper.Map<BillingFaceDto>(billingFace);
            return new CreateBillingFaceResponse() {Success = true, BillingFace = billingFaceDto};
        }
        else
            return new CreateBillingFaceResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateBillingFace};
    }
}