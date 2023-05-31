namespace SC.LK.Application.Domains.Dto;

public class ConfigurationsBusinessProcessViewDto
{
    public System.Guid Id { get; set; }

    public System.Guid ConfigurationVersionId { get; set; }

    public System.Guid BusinessProcessId { get; set; }

    public int OrderNumber { get; set; }
}