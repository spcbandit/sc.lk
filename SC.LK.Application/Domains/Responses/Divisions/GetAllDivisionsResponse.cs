using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Divisions;

public class GetAllDivisionsResponse : BaseResponse
{
    /// <summary>
    /// Список подразделений
    /// </summary>
    public List<DivisionDto> Divisions { get; set; }
}