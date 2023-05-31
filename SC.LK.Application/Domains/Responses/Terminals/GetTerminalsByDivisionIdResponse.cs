using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;

namespace SC.LK.Application.Domains.Responses.Terminals;

public class GetTerminalsByDivisionIdResponse: BaseResponse
{
    /// <summary>
    /// Терминал
    /// </summary>
    public TerminalsByIdDto Terminals { get; set; }
}