using MediatR;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Domains.Requests.InstructionsParameters;

public class DeleteParametersRequest:IRequest<DeleteParametersResponse>
{
    public Guid ParametersId { get; set; }
}