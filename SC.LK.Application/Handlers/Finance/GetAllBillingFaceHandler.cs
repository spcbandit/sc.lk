using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Finance;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Handlers.Finance;

public class GetAllBillingFaceHandler : IRequestHandler<GetAllBillingFaceRequest, GetAllBillingFaceResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IMapper _mapper;   
    
    /// <summary>
    /// Получение всех билинг лиц
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllBillingFaceHandler(IRepository<ContractorEntity> repositoryContractor, IMapper mapper)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Получение всех билинг лиц
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllBillingFaceResponse> Handle(GetAllBillingFaceRequest request, CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor
            .GetWithInclude(x => x.Id == request.ContractorId,
                x => x.BillingFaces)
            .FirstOrDefault();
        
        if (contractor != null)
        {
            var billingFaces = _mapper.Map<List<BillingFaceDto>>(contractor.BillingFaces);
            return new GetAllBillingFaceResponse() {Success = true, BillingFaces = billingFaces};
        }
        else
            return new GetAllBillingFaceResponse() {Success = false, ErrorMessage = MessageResource.FailedGetBillingFaces};
    }
}