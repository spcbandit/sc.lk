using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Domains.Responses.InstructionsParameters;

public class GetParametersByParametersIdResponse:BaseResponse
{
    public InstructionsParameterDto ParameterDto { get; set; }
}