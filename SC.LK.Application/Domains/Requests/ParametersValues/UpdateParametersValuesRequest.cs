using MediatR;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Domains.Requests.ParametersValues;

public class UpdateParametersValuesRequest:IRequest<UpdateParametersValuesResponse>
{
    public InstructionsParametersValueDto ParametersValueDto { get; set; }
}