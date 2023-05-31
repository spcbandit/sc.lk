using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class GetAllBusinessProcessHandler: IRequestHandler<GetAllBusinessProcessRequest, GetAllBusinessProcessResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllBusinessProcessHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient, IMapper mapper)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllBusinessProcessResponse> Handle(GetAllBusinessProcessRequest request, CancellationToken cancellationToken)
    {
        //get token
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var businessProcess = await _repositoryConfigurationServiceAdaptor.GetBusinessProcessByKontragentIdAsync(request.ContractorId);
        
        var mapBusinessProcess = _mapper.Map<List<BusinessProcessViewDto>>(businessProcess);
        
        if (businessProcess != null)
            return new GetAllBusinessProcessResponse() {Success = true, BusinessProceses = mapBusinessProcess};
        else
            return new GetAllBusinessProcessResponse() {Success = false, ErrorMessage = MessageResource.FailedGetConfigurations}; 
    }
}