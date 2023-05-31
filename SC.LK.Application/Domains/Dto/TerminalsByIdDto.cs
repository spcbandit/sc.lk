namespace SC.LK.Application.Domains.Dto;

public class TerminalsByIdDto
{
    public System.Guid KontragentId { get; set; }
    
    public System.Guid DivisionId { get; set; }
    public List<TerminalByIdDto> Terminals { get; set; }
}