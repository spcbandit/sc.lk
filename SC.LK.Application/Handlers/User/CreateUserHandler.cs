using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;
using RoleType = SC.LK.Application.Domains.IdentityService.Requests.RoleType;
using Services = SC.LK.Application.Domains.IdentityService.Requests.Services;
using UsersRoles = SC.LK.Application.Domains.IdentityService.Requests.UsersRoles;

namespace SC.LK.Application.Handlers.Profile;

internal class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IISClient _iisClient;
    private readonly IMailKit _mailKit;
    private readonly Random _generateCode;

    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="repositoryUser"></param>
    /// <param name="iisClient"></param>
    /// <param name="repositoryContractor"></param>
    public CreateUserHandler(IRepository<UserEntity> repositoryUser, IISClient iisClient,
        IRepository<ContractorEntity> repositoryContractor, IMapper mapper, IMailKit mailKit)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _mailKit = mailKit ?? throw new ArgumentException(nameof(mailKit));
        _generateCode = new Random();
    }

    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {


            // проверка уровня доступа user
            var mainUser = _repositoryUser.FindById(request.CreatorUserId);

            if (!IsLoginValid(request.Login, out var errorLogin))
                return new CreateUserResponse() {Success = false, ErrorMessage = errorLogin};

            if (request.Login.Any(Char.IsUpper))
                return new CreateUserResponse()
                    {Success = false, ErrorMessage = "В логине не должно быть заглавных букв"};

            // проверка на созданого user
            var canCreate = _repositoryUser.Get(x => x.Login == request.Login && x.IsDelete != true).FirstOrDefault();

            if (canCreate != null)
            {
                return new CreateUserResponse()
                {
                    Success = false,
                    ErrorMessage = MessageResource.MailIsUsed
                };
            }

            var contractor = _repositoryContractor
                .GetWithInclude(x => x.Id == request.ContractorId,
                    x => x.Users)
                .FirstOrDefault();

            var serviceToken = await _iisClient.TokenAsync(null);

            _iisClient.AuthHeader = serviceToken.JSON;

            var password = GenPassword(6);

            CreateUserInDB(request,password, out var user);

            contractor.Users.Add(user);

            await _mailKit.SendMessage(request.Login,
                "Вас приветствует CTSoft Enterprise! На нашей платформе был создан аккаунт с использованием вашей почты. <br> " +
                $"Ваш логин: {user.Login}<br>" +
                $"Ваш пароль для входа {password}<br><br> " +
                "Если вы никак не связаны с нашей платформой и аккаунт бы создан по ошибке сообщите нам: support@ctsoft-enterprise.ru");

            if (_repositoryContractor.Update(contractor) != 0)
            {
                var userDto = _mapper.Map<BaseUserDto>(user);
                return new CreateUserResponse() {Success = true, User = userDto};
            }
            else
                return new CreateUserResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateUser};
        }
        catch (Exception e)
        {
            return new CreateUserResponse() {Success = false, ErrorMessage = e.StackTrace};
        }
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
    /// <summary>
    /// Валидация логина
    /// </summary>
    /// <param name="login"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    private bool IsLoginValid(string login, out string error)
    {
        error = string.Empty;
        var checkLogin = _repositoryUser.Get(x => x.Login == login && x.IsDelete != true);
        if (checkLogin.Count() != 0)
        {
            error = MessageResource.LoginIsUsed;
            return false;
        }

        return true;
    }
    
    /// <summary>
    /// Хэширование пароля
    /// </summary>
    /// <param name="request"></param>
    private string GenPassword(int length)
    {
        string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }

    /// <summary>
    /// Установка свойств роли 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="role"></param>

    /// <summary>
    /// Отправка в базу данных пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="role"></param>
    /// <param name="user"></param>
    private void CreateUserInDB(CreateUserRequest request,string password,out UserEntity user)
    {
        
        user = new UserEntity()
        {
            MainContractor = request.ContractorId,
            Login = request.Login,
            Family = string.Empty,
            Name = string.Empty,
            Parent = string.Empty,
            Password = GetHash(password),
            IsActive = false,
            IsDelete = false,
            AuthCode = _generateCode.Next(0, 1000000).ToString("D6"),
            AvailableRoles = request.AvailableRoles,
            IsSuper = request.IsSuper
        };
        _repositoryUser.Create(user);
    }
}