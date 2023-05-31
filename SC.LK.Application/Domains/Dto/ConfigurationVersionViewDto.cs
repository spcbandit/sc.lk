namespace SC.LK.Application.Domains.Dto;

public class ConfigurationVersionViewDto
{
    public System.Guid ConfigurationVersionId { get; set; }
    
    public System.Guid ConfigurationId { get; set; }
    
    public int ConfigurationVersionNumber { get; set; }
    
    public string JsonHeader { get; set; }
    
    public bool IsActive { get; set; }
    
    public System.Collections.Generic.ICollection<ConfigurationsBusinessProcessViewDto> Proceses { get; set; } =
        new System.Collections.ObjectModel.Collection<ConfigurationsBusinessProcessViewDto>();
    
    public string UpdateBy { get; set; }
    
    public System.DateTimeOffset Update { get; set; }

}