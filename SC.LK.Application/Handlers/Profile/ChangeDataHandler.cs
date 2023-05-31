using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

internal class ChangeDataHandler : IRequestHandler<ChangeDataRequest, ChangeDataResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="repositoryUser"></param>
    public ChangeDataHandler(IRepository<UserEntity> repositoryUser, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Изменение данных пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ChangeDataResponse> Handle(ChangeDataRequest request, CancellationToken cancellationToken)
    {
        var userInfo = _repositoryUser.FindById(request.Id);

        userInfo.Name = request.Name;
        userInfo.Family = request.Family;
        userInfo.Parent = request.Parent;
        userInfo.Updated = DateTime.Now;
        userInfo.Login = request.Email;

        var res = _repositoryUser.Update(userInfo);
        
        if (res == 1)
        {
            var userInfoDto = _mapper.Map<UserDto>(userInfo);
            return new ChangeDataResponse() {Success = true, UserEntity = userInfoDto};
        }
        else
            return new ChangeDataResponse()
                {Success = false, ErrorMessage = MessageResource.FailedChangeData};
    }
}