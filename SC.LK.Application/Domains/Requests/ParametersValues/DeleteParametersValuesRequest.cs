using MediatR;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Domains.Requests.ParametersValues;

public class DeleteParametersValuesRequest:IRequest<DeleteParametersValuesResponse>
{
    public Guid ParametersValuesId { get; set; }
}