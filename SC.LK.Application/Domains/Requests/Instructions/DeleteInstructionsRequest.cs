using MediatR;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Domains.Requests.Instructions;

public class DeleteInstructionsRequest:IRequest<DeleteInstructionsResponse>
{
    public Guid InstructionsId { get; set; }
}
