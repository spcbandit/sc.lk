using MediatR;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Domains.Requests.Instructions;

public class AddInstructionsRequest:IRequest<AddInstructionsResponse>
{
    public InstructionsRootDto InstructionsDto { get; set; }
}