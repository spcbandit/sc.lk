namespace SC.LK.Application.Domains.Dto;

public class BusinessProcessViewDto
{
    public System.Guid BusinessProcessId { get; set; }

    public System.Guid KontragentId { get; set; }

    public string BusinessProcessName { get; set; }

    public string BusinessProcessDescription { get; set; }

    public bool IsTemplate { get; set; }

    public string JsonBody { get; set; }

    public System.Collections.Generic.ICollection<ConfigurationsBusinessProcessViewDto> ConfigurationVersions { get; set; } = new System.Collections.ObjectModel.Collection<ConfigurationsBusinessProcessViewDto>();

}