namespace SC.LK.Application.Domains.Dto;

public class ConfigurationVersionSignViewDto
{
    public System.Guid KontragentId { get; set; }
    
    public System.Guid TerminalId { get; set; }

    public System.Guid AgentId { get; set; }
    
    public string ConfigurationVersion { get; set; }
}