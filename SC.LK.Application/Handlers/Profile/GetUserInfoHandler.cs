using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class GetUserInfoHandler : IRequestHandler<GetUserInfoRequest, GetUserInfoResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение информации о пользователе
    /// </summary>
    /// <param name="repositoryUser"></param>
    public GetUserInfoHandler(IRepository<UserEntity> repositoryUser, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));

    }
    
    /// <summary>
    /// Получение информации о пользователе
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetUserInfoResponse> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
    {
        var userInfo = _repositoryUser.FindById(request.UserId);
        var userWithContractors = _repositoryUser.GetWithInclude(x => x.Id == request.UserId, x=>x.Сontractor).FirstOrDefault();
        var userInfoDto = _mapper.Map<UserInfoDto>(userInfo);
        var ucontractorsDto = _mapper.Map<List<BaseContractorDto>>(userWithContractors.Сontractor);
        if (userInfo != null)
            return new GetUserInfoResponse() {Success = true, UserInfo = userInfoDto, Contractors = ucontractorsDto};
        else
            return new GetUserInfoResponse()
                {Success = false, ErrorMessage = MessageResource.FailedGetUserInfo};
    }
}