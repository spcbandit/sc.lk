using MediatR;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class GetConfigurationVersionByTerminalIdRequest : IRequest<GetConfigurationVersionByTerminalIdResponse>
{
    public Guid TerminalId { get; set; }
}