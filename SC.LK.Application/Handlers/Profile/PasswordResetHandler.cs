using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class PasswordResetHandler : IRequestHandler<PasswordResetRequest, PasswordResetResponse>
{
    private readonly string _allowSpecialSymbols = "!@#$%^&*()-_+=;:,./?\\`~[]{}";
    private readonly string _allowSpecialNumbers = "0123456789";
    private readonly IRepository<UserEntity> _repositoryUser;

    /// <summary>
    /// Изменение пароля
    /// </summary>
    /// <param name="repositoryUser"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public PasswordResetHandler(IRepository<UserEntity> repositoryUser)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentNullException(nameof(repositoryUser));
    }

    /// <summary>
    /// Изменение пароля
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PasswordResetResponse> Handle(PasswordResetRequest request, CancellationToken cancellationToken)
    {
        if (!IsPasswordValid(request.Password, out var errorPass))
            return new PasswordResetResponse() {Success = false, ErrorMessage = errorPass};
        
        var user = _repositoryUser.Get(x => x.Login == request.Login && x.AuthCode == request.AuthCode && x.IsDelete !=true).FirstOrDefault();
        
        if (user == null)
            return new PasswordResetResponse() {Success = false, ErrorMessage = "Код не верен"};
        
        user.Password = GetHash(request.Password);
        
        if (_repositoryUser.Update(user) != 0)
            return new PasswordResetResponse() {Success = true};
        else
            return new PasswordResetResponse() {Success = false, ErrorMessage = "Ошибка изменения пароля"};
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
