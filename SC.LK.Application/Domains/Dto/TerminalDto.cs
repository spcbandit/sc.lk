namespace SC.LK.Application.Domains.Dto;

public class TerminalDto : Domains.BaseDto
{
    /*
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Deviceid
    /// </summary>
    public string? Deviceid { get; set; }

    /// <summary>
    /// AddedScanner
    /// </summary>
    public DateTime? AddedScanner { get; set; }

    /// <summary>
    /// Подразделение
    /// </summary>
    public DivisionDto? Division { get; set; }

    public Guid? SubscriptionId { get; set; }

    /// <summary>
    /// Подписка
    /// </summary>
    public SubscriptionDto? Subscription { get; set; }
    */
    
    [Newtonsoft.Json.JsonProperty("terminalId")]
    public System.Guid TerminalId { get; set; }

    [Newtonsoft.Json.JsonProperty("kontragentId")]
    public System.Guid KontragentId { get; set; }

    [Newtonsoft.Json.JsonProperty("divisionId")]
    public System.Guid DivisionId { get; set; }
        
    public string? DivisionName { get; set; }

    public string? TerminalName { get; set; }

    [Newtonsoft.Json.JsonProperty("subscriptionsEnd")]
    public string? SubscriptionsEnd { get; set; }

    [Newtonsoft.Json.JsonProperty("agentId")]
    public System.Guid AgentId { get; set; }
        
    public string? AgentName { get; set; }

    [Newtonsoft.Json.JsonProperty("configurationId")]
    public System.Guid ConfigurationId { get; set; }

    public string? ConfigurationName { get; set; }
        
    [Newtonsoft.Json.JsonProperty("updateBy")]
    public string? UpdateBy { get; set; }

    [Newtonsoft.Json.JsonProperty("update")]
    public string? Update { get; set; }

    [Newtonsoft.Json.JsonProperty("hardwareId")]
    public string? HardwareId { get; set; }

    [Newtonsoft.Json.JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [Newtonsoft.Json.JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }

    [Newtonsoft.Json.JsonProperty("currentVersion")]
    public string? CurrentVersion { get; set; }

    [Newtonsoft.Json.JsonProperty("licenceId")]
    public System.Guid LicenceId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("brand")]
    public string? Brand { get; set; }
        
    [Newtonsoft.Json.JsonProperty("model")]
    public string? Model { get; set; }
        
    [Newtonsoft.Json.JsonProperty("serial")]
    public string? Serial { get; set; }
        
    [Newtonsoft.Json.JsonProperty("androidRelease")]
    public string? AndroidRelease { get; set; }
}