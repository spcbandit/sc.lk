using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Divisions;

public class CreateDivisionResponse : BaseResponse
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public DivisionDto Division { get; set; }
}
