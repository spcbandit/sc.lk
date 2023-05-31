namespace SC.LK.Application.Domains.Entities;

public class NotificationEntity:BaseEntity
{
    public string Text { get; set; }
    public string Header { get; set; }
    public int Read { get; set; }
    public DateTime Expire { get; set; }
    public int Importance { get; set; }
    public Guid ContractorId { get; set; }
}