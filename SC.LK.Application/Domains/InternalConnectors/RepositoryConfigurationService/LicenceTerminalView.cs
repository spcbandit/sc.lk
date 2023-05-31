namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class LicenceTerminalView
{
    public Guid KontragentId { get; set; }
    
    public Guid TerminalId { get; set; }
    
    public Guid LicenceId { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime SubscriptionsEnd { get; set; }
}