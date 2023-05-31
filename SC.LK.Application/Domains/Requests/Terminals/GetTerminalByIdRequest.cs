using MediatR;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class GetTerminalByIdRequest: IRequest<GetTerminalByIdResponse>
{
    /// <summary>
    /// TerminalId
    /// </summary>
    public Guid TerminalId { get; set; }
}