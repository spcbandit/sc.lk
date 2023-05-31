using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Handlers.Divisions;

public class CreateDivisionHandler : IRequestHandler<CreateDivisionRequest, CreateDivisionResponse>
{
    private readonly IRepository<DivisionEntity> _repositoryDivision;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;

    /// <summary>
    /// Создание подразделения
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public CreateDivisionHandler(IRepository<DivisionEntity> repositoryDivision, IISClient iisClient, IMapper mapper)
    {
        _repositoryDivision = repositoryDivision ?? throw new ArgumentException(nameof(repositoryDivision));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Создание подразделения
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateDivisionResponse> Handle(CreateDivisionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _iisClient.AuthHeader = serviceToken.JSON;

        var division = new DivisionEntity()
        {
            Address = request.Address,
            PIN = "0",
            Name = request.Name,
            Host = "",
            IsActive = false,
            СontractorId = request.ContractorId
        };
        
        var res= _repositoryDivision.Create(division);
        
        if (res != 0)
        {
            var res2 = _repositoryDivision.Update(division);

            var divisionDto = _mapper.Map<DivisionDto>(division);

            if (res2 != 0)
                return new CreateDivisionResponse() {Success = true, Division = divisionDto};
            else
                return new CreateDivisionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateDivision};
        }
        else
            return new CreateDivisionResponse() {Success = false, ErrorMessage =  MessageResource.FailedCreateDivision};
    }
}