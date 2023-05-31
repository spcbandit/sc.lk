using MediatR;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class UpdateTerminalRequest: IRequest<UpdateTerminalResponse>
{
    /// <summary>
    /// TerminalId
    /// </summary>
    public Guid TerminalId { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    public TerminalView Terminal { get; set; }
}