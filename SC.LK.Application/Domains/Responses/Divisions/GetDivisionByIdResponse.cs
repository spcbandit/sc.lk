using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Divisions;

public class GetDivisionByIdResponse : BaseResponse
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public DivisionDto Division { get; set; }
}