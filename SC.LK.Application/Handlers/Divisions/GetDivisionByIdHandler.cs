using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Handlers.Divisions;

public class GetDivisionByIdHandler : IRequestHandler<GetDivisionByIdRequest, GetDivisionByIdResponse>
{
    private readonly IRepository<DivisionEntity> _repositoryDivision;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение подразделения по ID
    /// </summary>
    /// <param name="repositoryDivision"></param>
    public GetDivisionByIdHandler(IRepository<DivisionEntity> repositoryDivision, IMapper mapper)
    {
        _repositoryDivision = repositoryDivision ?? throw new ArgumentException(nameof(repositoryDivision));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Получение подразделения по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetDivisionByIdResponse> Handle(GetDivisionByIdRequest request, CancellationToken cancellationToken)
    {
        var division = _repositoryDivision.FindById(request.DivisionId);
        var divisionDto = _mapper.Map<DivisionDto>(division);
        if(division != null)
            return new GetDivisionByIdResponse() {Success = true, Division = divisionDto};
        else
            return new GetDivisionByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetDivision};
    }
}