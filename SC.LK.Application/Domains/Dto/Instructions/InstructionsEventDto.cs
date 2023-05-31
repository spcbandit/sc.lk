namespace SC.LK.Application.Domains.Dto;

public class InstructionsEventDto
{
    public Guid EventsId { get; set; }

    public Guid InstructionId { get; set; }

    public int EventName { get; set; }

    public bool Enabled { get; set; }

    public int OutputData { get; set; }
}