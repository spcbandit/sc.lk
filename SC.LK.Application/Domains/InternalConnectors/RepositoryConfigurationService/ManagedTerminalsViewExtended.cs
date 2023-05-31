namespace SC.LK.Application.Domains.RepositoryConfigurationService;

public class ManagedTerminalsViewExtended
{
    public System.Guid? KontragentId { get; set; }

    public System.Guid? DivisionId { get; set; }
    public List<TerminalView> Terminals { get; set; } = new List<TerminalView>();

}