using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Handlers.Profile;

public class UpdateUserHandler: IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Обновление профиля
    /// </summary>
    /// <param name="repositoryUser"></param>
    public UpdateUserHandler(IRepository<UserEntity> repositoryUser, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));

    }
    
    /// <summary>
    /// Обновление профиля
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryUser.GetWithInclude(x=>x.Id == request.UserId).FirstOrDefault();
        user.Family = request.Family;
        user.Name = request.Name;
        user.Parent = request.Parent;
        user.Updated = DateTime.Now;
        user.AvailableRoles = request.AvailableRoles;
        //user.IsSuper = request.IsSuper;
        
        var res= _repositoryUser.Update(user);    

        if (res != 0 && user.AvailableRoles != Guid.Empty)
        {
            var userDto = _mapper.Map<BaseUserDto>(user);
            return new UpdateUserResponse() {Success = true, User = userDto};
        }
        else
            return new UpdateUserResponse()
                {Success = false, ErrorMessage = MessageResource.FailedUpdateUser};
    }
    
}