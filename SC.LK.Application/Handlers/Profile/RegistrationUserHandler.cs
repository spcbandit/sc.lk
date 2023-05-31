using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp.Extensions;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;
using LoginRequest = SC.LK.Application.Domains.IdentityService.Requests.LoginRequest;
using RoleType = SC.LK.Application.Domains.IdentityService.Requests.RoleType;
using Services = SC.LK.Application.Domains.IdentityService.Requests.Services;
using UsersRoles = SC.LK.Application.Domains.IdentityService.Requests.UsersRoles;

namespace SC.LK.Application.Handlers.Profile
{
    internal class RegistrationUserHandler: IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly string _allowSpecialSymbols = "!@#$%^&*()-_+=;:,./?\\`~[]{}";
        private readonly string _allowSpecialNumbers = "0123456789";
        private readonly IRepository<UserEntity> _repositoryUser;
        private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
        private readonly IRepository<ContractorEntity> _repositoryContractor;
        private readonly IMapper _mapper;
        private readonly ISigningEncryptionAdaptor _signingEncryptionAdaptor;
        private readonly IISClient _iisClient;
        private readonly IMailKit _mailKit;
        private readonly Random _generateCode;
        private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="repositoryUser"></param>
        /// <param name="repositoryBillingFace"></param>
        /// <param name="repositoryContractor"></param>
        /// <param name="iisClient"></param>
        /// <param name="daDataClient"></param>
        public RegistrationUserHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IRepository<UserEntity> repositoryUser,
            IRepository<BillingFaceEntity> repositoryBillingFace, 
            IRepository<ContractorEntity> repositoryContractor,
            IMapper mapper, ISigningEncryptionAdaptor signingEncryptionAdaptor, 
            IISClient isClient, IMailKit mailKit)
        {
            _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
            _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
            _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _signingEncryptionAdaptor = signingEncryptionAdaptor ?? throw new ArgumentException(nameof(signingEncryptionAdaptor));
            _iisClient = isClient ?? throw new ArgumentException(nameof(isClient));
            _mailKit = mailKit ?? throw new ArgumentException(nameof(mailKit));
            _generateCode = new Random();
            _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        }
        
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            if (!IsPasswordValid(request.Password, out var errorPass))
                return new RegistrationResponse() {Success = false, ErrorMessage = errorPass};
            
            if (request.Login.Any(Char.IsUpper))
                return new RegistrationResponse() {Success = false, ErrorMessage = "В логине не должно быть заглавных букв"};
            
            if (!IsLoginValid(request.Login, out var errorLogin))
                return new RegistrationResponse() {Success = false, ErrorMessage = errorLogin};

            if (!IsInnValid(request.ContractorINN, out var errorInn))
                return new RegistrationResponse() {Success = false, ErrorMessage = errorInn};
            Guid adminGuid = new Guid("08daadc6-a774-4b18-86a3-eed249385cb7");
            var user = new UserEntity()
            {
                Login = request.Login,
                Parent = request.Parent,
                Name = request.Name,
                Family = request.Family,
                Password = GetHash(request.Password),
                AuthCode = _generateCode.Next(0, 1000000).ToString("D6"),
                IsActive = false,
                IsDelete = false,
                AvailableRoles = adminGuid,
            };

            await _mailKit.SendMessage(request.Login, user.AuthCode);

            var contractor = new ContractorEntity()
            {
                Name = request.ContractorName,
                Keys = new KeysEntity(),
                Partner = false,
                ParentContractor = null,
                Type = ContractorType.Client,
                Status = ContractorStatusType.New
            };

            var billingFace = new List<BillingFaceEntity>()
            {
                new ()
                {
                    INN = request.ContractorINN,
                    PaymentSystem = new PaymentSystemEntity(),
                    СontractorId = contractor.Id
                }
            };
            
            contractor.BillingFaces = billingFace;
            
            if(_repositoryContractor.Create(contractor) == 0)
                return new RegistrationResponse() {Success = false, ErrorMessage = MessageResource.FailedRegister};
            
            /*using (StreamReader reader = new StreamReader("pricecontrol.txt"))
            {
                var text = await reader.ReadToEndAsync();
                var id = await CreateBusinessProcess(contractor.Id, "Контроль цен", "{}");
                await UpdateBusinessProcess(contractor.Id, id, text);

            }

            using (StreamReader reader = new StreamReader("recount.txt"))
            {
                var text = await reader.ReadToEndAsync();
                var id = await CreateBusinessProcess(contractor.Id, "Инвентаризация", "{}");
                await UpdateBusinessProcess(contractor.Id, id, text);
            }
            
            using (StreamReader reader = new StreamReader("acceptance.txt"))
            {
                var text = await reader.ReadToEndAsync();
                var id = await CreateBusinessProcess(contractor.Id, "Приемка", "{}");
                await UpdateBusinessProcess(contractor.Id, id, text);
            }
            
            using (StreamReader reader = new StreamReader("shipment.txt"))
            {
                var text = await reader.ReadToEndAsync();
                var id = await CreateBusinessProcess(contractor.Id, "Отгрузка", "{}");
                await UpdateBusinessProcess(contractor.Id, id, text);
            }
            using (StreamReader reader = new StreamReader("moving.txt"))
            {
                var text = await reader.ReadToEndAsync();
                var id = await CreateBusinessProcess(contractor.Id, "Перемещение", "{}");
                await UpdateBusinessProcess(contractor.Id, id, text);
            }*/
            
            var serviceToken = await _iisClient.TokenAsync(null);
            _signingEncryptionAdaptor.AuthHeader = serviceToken.JSON;
            
            bool res = await _signingEncryptionAdaptor.GenerateCertificateKontragentAsync(contractor.Id);
            var error = "";
            if (!res)
            {
                error = "Сертификат не был зарегистрирован!";
            }
            
            user.MainContractor = contractor.Id;
            user.Сontractor = new List<ContractorEntity>() {contractor};
            
            if (_repositoryUser.Create(user) != 0)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new RegistrationResponse() {Success = true, User = userDto, ErrorMessage = error};
            }
            
            return new RegistrationResponse() {Success = false, ErrorMessage = MessageResource.FailedRegister};
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
        /// Валидация ИНН
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool IsInnValid(string inn, out string error)
        {
            error = string.Empty;
            var billingFaceInn = _repositoryBillingFace
                .GetWithInclude(x => x.INN == inn)
                .FirstOrDefault();
            if (billingFaceInn != null)
            {
                error = MessageResource.InnIsUsed;
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
        
        private async Task<Guid> CreateBusinessProcess(Guid contractorId, string name, string jsonBody)
        {
            try{
                //get token
                var serviceToken = await _iisClient.TokenAsync(null);
                _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

                //create businessProcess in repositoryConfigurationService
                var businessProcess = new BusinessProcessView()
                {
                    ConfigurationVersions = new List<ConfigurationsBusinessProcessView>(),
                    IsTemplate = false,
                    JsonBody = jsonBody,
                    KontragentId = contractorId,
                    BusinessProcessDescription = name,
                    BusinessProcessName = name
                };
                var requestBusinessProcess =
                    await _repositoryConfigurationServiceAdaptor.AddBusinessProcessAsync(businessProcess);

                if (requestBusinessProcess != null)
                    return requestBusinessProcess;
                else
                    return Guid.Empty;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            } 
        }

        private async Task<bool> UpdateBusinessProcess(Guid contractorId, Guid businessProcessId, string jsonBody)
        {
            var serviceToken = await _iisClient.TokenAsync(null);
            _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
            var businessProcess = await _repositoryConfigurationServiceAdaptor.GetBusinessProcessByBusinessProcessIdAsync(businessProcessId);
        
            if (businessProcess != null)
            {
                businessProcess.JsonBody = jsonBody;
            
                var res = await _repositoryConfigurationServiceAdaptor.UpdateBusinessProcessAsync(businessProcessId, businessProcess);

                if (res != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
