using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Handlers.Divisions;

public class GetAllDivisionsHandler: IRequestHandler<GetAllDivisionsRequest, GetAllDivisionsResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IISClient _iisClient;
    private IRepositoryConfigurationServiceAdaptor _cloudApiServiceAdaptor;
    private IMapper _mapper;
    //private readonly IMapper _mapper;   
    
    /// <summary>
    /// Получение всех подразделений
    /// </summary>
    /// <param name="repositoryContractor"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    public GetAllDivisionsHandler(IRepository<ContractorEntity> repositoryContractor, IRepositoryConfigurationServiceAdaptor cloudApiServiceAdaptor, IISClient iisClient, IMapper mapper)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _cloudApiServiceAdaptor = cloudApiServiceAdaptor ?? throw new ArgumentException(nameof(cloudApiServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        
    }
    
    /// <summary>
    /// Получение всех подразделений
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllDivisionsResponse> Handle(GetAllDivisionsRequest request, CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor
            .GetWithInclude(x => x.Id == request.ContractorId, 
                x=>x.Division)
            .FirstOrDefault();

        if (contractor != null)
        {
            var contractorDto = _mapper.Map<List<DivisionDto>>(contractor.Division);
            return new GetAllDivisionsResponse
            {
                Success = true,
                ErrorMessage = null,
                Divisions = contractorDto
            };
        }
        else
            return new GetAllDivisionsResponse() {Success = false, ErrorMessage = MessageResource.FailedGetDivisions};
    }
}