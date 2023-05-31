namespace SC.LK.Application.Domains.Dto;

public class TerminalByIdDto
{
    
    [Newtonsoft.Json.JsonProperty("brand")]
    public string? Brand { get; set; }
        
    [Newtonsoft.Json.JsonProperty("model")]
    public string? Model { get; set; }
        
    [Newtonsoft.Json.JsonProperty("serial")]
    public string? Serial { get; set; }
        
    [Newtonsoft.Json.JsonProperty("androidRelease")]
    public string? AndroidRelease { get; set; }
    
    public System.Guid? LicenceId { get; set; }
    public System.Guid TerminalId { get; set; }
    public System.Guid KontragentId { get; set; }
    public System.Guid DivisionId { get; set; }
    public string DivisionName { get; set; }
    public string TerminalName { get; set; }
    public DateTimeOffset SubscriptionsEnd { get; set; }
    public Guid AgentId { get; set; }
    public string AgentName { get; set; }
    public Guid? ConfigurationId { get; set; }
    public string ConfigurationName { get; set; }
    public string UpdateBy { get; set; }
    public DateTimeOffset Update { get; set; }
    public string HardwareId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string CurrentVersion { get; set; }
    public Guid DistributiveId { get; set; }
}