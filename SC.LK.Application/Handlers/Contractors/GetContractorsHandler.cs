using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Handlers.Contractors;

public class GetContractorsHandler : IRequestHandler<GetContractorsRequest, GetContractorsResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="repositoryUser"></param>
    public GetContractorsHandler(IRepository<UserEntity> repositoryUser, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetContractorsResponse> Handle(GetContractorsRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryUser
            .GetWithInclude(x => x.Id == request.UserId, 
            x=>x.Сontractor)
            .FirstOrDefault();
        var contractors = _mapper.Map<List<BaseContractorDto>>(user.Сontractor);
        var mainContractor = contractors.FirstOrDefault(x => x.Id == user.MainContractor);
        mainContractor.IsMain = true;
        if (user != null)
            return new GetContractorsResponse() {Success = true, Contractors = new List<BaseContractorDto>(){mainContractor}};
        else
            return new GetContractorsResponse() {Success = false, ErrorMessage = MessageResource.FailedGetContractors};
    }
}