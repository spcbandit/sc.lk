using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Configurations;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Handlers.Configurations;

public class GetAllDivisionsTerminalsHandler: IRequestHandler<GetAllDivisionsTerminalsRequest, GetAllDivisionsTerminalsResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IRepository<DivisionEntity> _repositoryDivisions;
    

    //private readonly IMapper _mapper;   
    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllDivisionsTerminalsHandler(IRepository<DivisionEntity> repositoryDivisions, IRepository<ContractorEntity> repositoryContractor)
    {
        _repositoryDivisions = repositoryDivisions ?? throw  new ArgumentException(nameof(repositoryDivisions));
        _repositoryContractor = repositoryContractor ?? throw  new ArgumentException(nameof(repositoryContractor));
    }

    /// <summary>
    /// Получение всех Конфигураций
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllDivisionsTerminalsResponse> Handle(GetAllDivisionsTerminalsRequest request, CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor
            .GetWithInclude(x => x.Id == request.ContractorId,
                x => x.Division)
            .FirstOrDefault();
        
        List<Guid> divisionsId = contractor.Division.Select(x => x.Id).ToList();

        var divisions = _repositoryDivisions
            .GetWithInclude(x => divisionsId.Contains(x.Id), 
                x => x.Terminals).ToList();
        
        var divisionsTerminalsDto = new List<DivisionsTerminalsDtoRes>();

        foreach (var division in divisions)
        {
            foreach (var terminal in division.Terminals)
            {
                var divisionTerminalsDto = new DivisionsTerminalsDtoRes()
                {
                    DivisionId = division.Id,
                    DivisionName = division.Name,
                    TerminalId = terminal.Id,
                    TerminalName = terminal.Name,
                };
                divisionsTerminalsDto.Add(divisionTerminalsDto);
            }
        }

        if (divisionsTerminalsDto != null)
            return new GetAllDivisionsTerminalsResponse() {Success = true, DtoRes = divisionsTerminalsDto};
        else
            return new GetAllDivisionsTerminalsResponse() {Success = false, ErrorMessage = MessageResource.FailedGetConfigurations};
    }
}