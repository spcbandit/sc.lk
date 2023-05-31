using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Handlers.Tickets;

public class DeleteTicketHandler: IRequestHandler<DeleteTicketRequest, DeleteTicketResponse>
{
    internal readonly IRepository<TicketEntity> _repositoryTicket;

    /// <summary>
    /// Удаление заявки
    /// </summary>
    public DeleteTicketHandler(IRepository<TicketEntity> ticket)
    {
        _repositoryTicket = ticket;
    }
    
    /// <summary>
    /// Удаление заявки
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteTicketResponse> Handle(DeleteTicketRequest request, CancellationToken cancellationToken)
    {
        var ticket = _repositoryTicket.FindById(request.TicketId);
        var res = _repositoryTicket.Remove(ticket);
        if (res != 0) 
            return new DeleteTicketResponse() {Success = true};
        else
            return new DeleteTicketResponse() {Success = false, ErrorMessage = ""};
    }
}