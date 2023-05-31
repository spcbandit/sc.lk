using MediatR;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class CreateTerminalRequest: IRequest<CreateTerminalResponse>
{
    public TerminalView Terminal { get; set; }
}