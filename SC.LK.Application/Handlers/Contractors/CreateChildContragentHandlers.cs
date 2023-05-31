using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Contractors;

public class CreateChildContragentHandlers: IRequestHandler<CreateChildContragentRequest, CreateChildContragentResponse>
{
    private readonly IRepository<BillingFaceEntity> _repositoryBillingFace;
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMapper _mapper;
    private readonly IISClient _iisClient;
    private readonly ISigningEncryptionAdaptor _signingEncryptionAdaptor;
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;


    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="repositoryUser"></param>
    public CreateChildContragentHandlers(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IRepository<UserEntity> repositoryUser, IRepository<BillingFaceEntity> repositoryBillingFace, IMapper mapper, ISigningEncryptionAdaptor signingEncryptionAdaptor, 
        IISClient isClient, IRepository<ContractorEntity> repositoryContractor)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _signingEncryptionAdaptor = signingEncryptionAdaptor ?? throw new ArgumentException(nameof(signingEncryptionAdaptor));
        _iisClient = isClient ?? throw new ArgumentException(nameof(isClient));
        _repositoryBillingFace = repositoryBillingFace ?? throw new ArgumentException(nameof(repositoryBillingFace));
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));

    }
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateChildContragentResponse> Handle(CreateChildContragentRequest request, CancellationToken cancellationToken)
    {
        if (!IsInnValid(request.ContractorINN, out var errorInn))
            return new CreateChildContragentResponse() {Success = false, ErrorMessage = errorInn};
        
        var user = _repositoryUser.GetWithInclude(x => x.Id == request.UserId, x=>x.Сontractor).FirstOrDefault();
        
        var contractor = new ContractorEntity()
        {
            Name = request.ContractorName,
            Keys = new KeysEntity(),
            Partner = false,
            ParentContractorId = request.ContractorId,
            Type = request.ContractorType,
            Status = ContractorStatusType.New
        };

        var billingFace = new List<BillingFaceEntity>()
        {
            new BillingFaceEntity()
            {
                INN = request.ContractorINN,
                PaymentSystem = new PaymentSystemEntity(),
                СontractorId = contractor.Id
            }
        };
            
        contractor.BillingFaces = billingFace;

        if(_repositoryContractor.Create(contractor) == 0)
            return new CreateChildContragentResponse() {Success = false, ErrorMessage = "не удалось создать контагента"};
            
        using (StreamReader reader = new StreamReader("pricecontrol.txt"))
        {
            var text = await reader.ReadToEndAsync();
            var id = await CreateBusinessProcess(contractor.Id, "Контроль цен", "{}");
            await UpdateBusinessProcess(contractor.Id, id, text);

        }

        using (StreamReader reader = new StreamReader("recount.txt"))
        {
            var text = await reader.ReadToEndAsync();
            var id = await CreateBusinessProcess(contractor.Id, "Перерасчет", "{}");
            await UpdateBusinessProcess(contractor.Id, id, text);
        }
        
        var serviceToken = await _iisClient.TokenAsync(null);
        _signingEncryptionAdaptor.AuthHeader = serviceToken.JSON;
            
        bool res = await _signingEncryptionAdaptor.GenerateCertificateKontragentAsync(contractor.Id);
        var error = "";
        if (!res)
        {
            error = "Сертификат не был зарегистрирован!";
        }
        
        user.Сontractor.Add(contractor);
        var update = _repositoryUser.Update(user);
        if (update != 0)
        {
            var mapContractor = _mapper.Map<BaseContractorDto>(contractor);
            return new CreateChildContragentResponse() {Success = true, ContractorId = mapContractor.Id, ErrorMessage = error};
        }
        else
            return new CreateChildContragentResponse() {Success = false, ErrorMessage = ""};
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
                    BusinessProcessDescription = "BusinessProcess",
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