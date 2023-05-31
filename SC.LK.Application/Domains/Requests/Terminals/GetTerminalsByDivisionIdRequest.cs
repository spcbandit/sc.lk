using MediatR;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class GetTerminalsByDivisionIdRequest: IRequest<GetTerminalsByDivisionIdResponse>
{
    /// <summary>
    /// DivisionId
    /// </summary>
    public Guid DivisionId { get; set; }
}