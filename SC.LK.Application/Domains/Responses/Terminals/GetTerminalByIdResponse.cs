using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Terminals;

public class GetTerminalByIdResponse: BaseResponse
{
    /// <summary>
    /// Терминал
    /// </summary>
    public TerminalDto Terminal { get; set; }
}