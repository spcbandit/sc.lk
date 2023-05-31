using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Handlers.Contractors;

public class GetChildContragentsHandlers : IRequestHandler<GetChildContragentsRequest, GetChildContragentsResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="repositoryUser"></param>
    public GetChildContragentsHandlers(IRepository<UserEntity> repositoryUser, IRepository<ContractorEntity> repositoryContractor, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetChildContragentsResponse> Handle(GetChildContragentsRequest request, CancellationToken cancellationToken)
    {
        List<BaseContractorDto> contractors = null;
        if (request.MainContractorId == Guid.Parse("00000000-0000-0000-0000-000000000001"))
        {
            var contractorEntities = _repositoryContractor
                .Get()
                .ToList();
            contractors = _mapper.Map<List<BaseContractorDto>>(contractorEntities);
        }
        else
        {
            //TODO : Добавить проверки принадлежности юзера к контрактору
            var listcontractors = _repositoryContractor
                .Get(x => x.ParentContractorId == request.MainContractorId)
                .ToList();
            
            contractors = _mapper.Map<List<BaseContractorDto>>(listcontractors);
        }

        if (contractors != null)
            return new GetChildContragentsResponse() {Success = true, Contractors = contractors};
        else
            return new GetChildContragentsResponse() {Success = false, ErrorMessage = MessageResource.FailedGetContractors};
    }
}