using MediatR;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class AddTerminalsToDivisionRequest : IRequest<AddTerminalsToDivisionResponse>
{
    public Guid DivisionId { get; set; }
    
    public List<Guid> TerminalsId { get; set; }
}