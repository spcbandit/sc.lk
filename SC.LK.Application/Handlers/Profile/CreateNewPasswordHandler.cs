using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class CreateNewPasswordHandler: IRequestHandler<CreateNewPasswordRequest, CreateNewPasswordResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly string _allowSpecialSymbols = "!@#$%^&*()-_+=;:,./?\\`~[]{}";
    private readonly string _allowSpecialNumbers = "0123456789";
    private readonly IMapper _mapper;
    private readonly IMailKit _mailKit;

    public CreateNewPasswordHandler(IRepository<UserEntity> repositoryUser, IMapper mapper, IMailKit mailKit)
    {
        _repositoryUser = repositoryUser;
        _mapper = mapper;
        _mailKit = mailKit;
    }

    public async Task<CreateNewPasswordResponse> Handle(CreateNewPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryUser.Get(x => x.Login == request.Login && x.IsDelete != true).FirstOrDefault();
        if (user is null)
        {
            return new CreateNewPasswordResponse() {Success = false, ErrorMessage = "Логин пользователя не найден"};
        }

        if (user.Password != GetHash(request.Password))
        {
            return new CreateNewPasswordResponse()
            {
                Success = false,
                ErrorMessage = "Введенный пароль не правильный. Введите пароль из письма создания аккаунта."
            };
        }

        if (user.AuthCode != request.Code)
        {
            return new CreateNewPasswordResponse() {Success = false, ErrorMessage = "Не верный пин-код!"};
        }
        
        if (!IsPasswordValid(request.NewPassword, out var errorPass))
            return new CreateNewPasswordResponse() {Success = false, ErrorMessage = errorPass};
        
        user.IsActive = true;
        user.Password = GetHash(request.NewPassword);
        var res = _repositoryUser.Update(user);
        
        if (res != 0)
        {
            return new CreateNewPasswordResponse() {Success = true};
        }
        else
        {
            return new CreateNewPasswordResponse()
                {Success = false, ErrorMessage = "Проблемы с подключением к серверу"};
        }
    }
    
    /// <summary>
    /// Валидация пароля
    /// </summary>
    /// <param name="password"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    private bool IsPasswordValid(string password, out string error)
    {
        Regex reg = new Regex("[a-zA-Z]");
        error = string.Empty;

        if (!reg.IsMatch(password))
        {
            error = "В пароле должена быть хотя бы одна буква.";
            return false;
        }

        if (password.Length < 6)
        {
            error = "Длина пароля должна быть больше чем 6 символов.";
            return false;
        }

        if (!(password.IndexOfAny(_allowSpecialSymbols.ToCharArray()) > -1))
        {
            error =
                "В пароле нужен хотя бы 1 специальный символ. Выберите что то из этого : [!@#$%^&*()-_+=;:,./?\\`~[]{}]";
            return false;
        }
            
        if (!(password.IndexOfAny(_allowSpecialNumbers.ToCharArray()) > -1))
        {
            error =
                "В пароле обязательно нужны цифры.";
            return false;
        }
        return true;
    }
    
    /// <summary>
    /// Хэширование строки
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    private string GetHash(string password)
    {
        var sha1 = new SHA1CryptoServiceProvider();
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
        return Encoding.UTF8.GetString(sha1.ComputeHash(plainTextBytes));
    }
}