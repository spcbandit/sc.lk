
using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Responses.Contractors;

public class GetContractorsResponse : BaseResponse
{
    /// <summary>
    /// Список контрагентов
    /// </summary>
    public List<BaseContractorDto> Contractors { get; set; }
}