namespace SC.LK.Application.Domains.Dto;

public class AgentsViewDto
{
    public Guid? KontragentId { get; set; }

    public Guid? DivisionId { get; set; }

    public List<AgentDto> Agents { get; set; }
}