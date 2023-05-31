namespace SC.LK.Application.Domains.Dto;

public class AgentDto
{
    public System.Guid AgentId { get; set; }

    public System.Guid KontragentId { get; set; }

    public System.Guid DivisionId { get; set; }

    public string HostName { get; set; }

    public string HostAddress { get; set; }

    public string HostFingerprint { get; set; }

    public string CurrentVersion { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string UpdateBy { get; set; }

    public System.DateTimeOffset Update { get; set; }

    public System.Guid DistributiveId { get; set; }
}