using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class ValidateCodeHandler : IRequestHandler<ValidateCodeRequest, ValidateCodeResponse>
{

    private readonly IRepository<UserEntity> _repositoryUser;

    /// <summary>
    /// Валидация токена пользователя
    /// </summary>
    /// <param name="repositoryUser"></param>
    /// <param name="isClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public ValidateCodeHandler(IRepository<UserEntity> repositoryUser, IMapper mapper)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
    }

    /// <summary>
    /// Валидация токена пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ValidateCodeResponse> Handle(ValidateCodeRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryUser
            .Get(x => x.Login == request.Login && x.IsDelete != true)
            .FirstOrDefault();
        
        if (user.AuthCode != request.AuthCode)
        {
            return new ValidateCodeResponse() {Success = false, ErrorMessage = "Неверный код авторизации"};
        }
        user.IsActive = true;
        
        if (_repositoryUser.Update(user) != 0)
            return new ValidateCodeResponse() {Success = true};
        else
            return new ValidateCodeResponse() {Success = false, ErrorMessage = "Не получилось активировать пользователя"};
    }
}