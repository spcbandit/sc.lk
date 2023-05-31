using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.ParametersValues;

public class GetParametersValuesByParametersValuesIdResponse:BaseResponse
{
    public InstructionsParametersValueDto ParametersValueDto { get; set; }
}