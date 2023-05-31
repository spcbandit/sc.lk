using MediatR;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Domains.Requests.ParametersValues;

public class GetParametersValuesByParametersValuesIdRequest:IRequest<GetParametersValuesByParametersValuesIdResponse>
{
    public Guid ParametersValuesId { get; set; }
}