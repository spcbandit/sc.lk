using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Responses.Contractors;

public class GetChildContragentsResponse : BaseResponse
{
    public List<BaseContractorDto> Contractors { get; set; }
}