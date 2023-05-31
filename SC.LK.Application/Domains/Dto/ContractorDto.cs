using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Dto;

public class ContractorDto : BaseContractorDto
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public List<UserDto> Users { get; set; }

    /// <summary>
    /// Биллинг лица
    /// </summary>
    public List<BillingFaceDto> BillingFaces { get; set; }

    /// <summary>
    /// Подразделения
    /// </summary>
    public List<DivisionDto> Division { get; set; } = new List<DivisionDto>();
    
}