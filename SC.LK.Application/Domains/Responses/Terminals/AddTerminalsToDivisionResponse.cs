using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Terminals;

public class AddTerminalsToDivisionResponse : BaseResponse
{
    public List<TerminalsToDivisionDto> TerminalsToDivision { get; set; }
}