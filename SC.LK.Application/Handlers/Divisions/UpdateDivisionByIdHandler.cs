using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Handlers.Divisions;

public class UpdateDivisionByIdHandler: IRequestHandler<UpdateDivisionByIdRequest, UpdateDivisionByIdResponse>
{
    private readonly IRepository<DivisionEntity> _repositoryDivision;
    private readonly IMapper _mapper;

    /// <summary>
    /// Обновить подразделение
    /// </summary>
    /// <param name="repositoryDivision"></param>
    public UpdateDivisionByIdHandler(IRepository<DivisionEntity> repositoryDivision, IMapper mapper)
    {
        _repositoryDivision = repositoryDivision ?? throw new ArgumentException(nameof(repositoryDivision));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Обновить подразделение
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateDivisionByIdResponse> Handle(UpdateDivisionByIdRequest request, CancellationToken cancellationToken)
    {
        var division = _repositoryDivision.FindById(request.DivisionId);
        division.Address = request.Address;
        division.Name = request.Name;
        division.Host = request.Host;
        division.IsActive = request.IsActive;
        var res = _repositoryDivision.Update(division);
        if (res != 0)
        {
            var divisionDto = _mapper.Map<DivisionDto>(division);
            return new UpdateDivisionByIdResponse() {Success = true, Division = divisionDto};
        }
        else
            return new UpdateDivisionByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateDivision};
    }
}