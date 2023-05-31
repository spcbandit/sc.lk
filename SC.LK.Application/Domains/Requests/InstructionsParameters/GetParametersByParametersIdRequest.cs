using MediatR;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Domains.Requests.InstructionsParameters;

public class GetParametersByParametersIdRequest:IRequest<GetParametersByParametersIdResponse>
{
    public Guid parametersId { get; set; }
   
}