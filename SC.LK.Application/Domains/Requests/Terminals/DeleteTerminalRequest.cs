using MediatR;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Domains.Requests.Terminals;

public class DeleteTerminalRequest: IRequest<DeleteTerminalResponse>
{
    /// <summary>
    /// TerminalId
    /// </summary>
    public Guid TerminalId { get; set; }
    
    public string UpdateBy { get; set; }

    public Guid KontragentId { get; set; }
    public Guid? LicenceId { get; set; }
}