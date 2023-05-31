using MediatR;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Domains.Requests.Instructions;

public class GetInstructionsByInstructionsIdRequest:IRequest<GetInstructionsByInstructionsIdResponse>
{
    public Guid InstructionsId { get; set; }
}