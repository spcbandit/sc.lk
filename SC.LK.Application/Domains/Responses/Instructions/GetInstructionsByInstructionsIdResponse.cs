using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;

namespace SC.LK.Application.Domains.Responses.Instructions;

public class GetInstructionsByInstructionsIdResponse:BaseResponse
{
    public InstructionsRootDto InstructionsRootDto { get; set; }
}