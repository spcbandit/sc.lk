namespace SC.LK.Application.Domains.Dto;

public class DistributivesDto
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string TerminalVersion { get; set; }
    public string AgentVersion { get; set; }
    public Guid DistributiveId { get; set; }
}