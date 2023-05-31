using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Handlers.Tickets;

public class UpdateStatusTicketHandler: IRequestHandler<UpdateStatusTicketRequest, UpdateStatusTicketResponse>
{
    internal readonly IRepository<TicketEntity> _repositoryTicket;

    /// <summary>
    /// Обновить статус заявки
    /// </summary>
    public UpdateStatusTicketHandler(IRepository<TicketEntity> ticket)
    {
        _repositoryTicket = ticket;
    }
    
    /// <summary>
    /// Обновить статус заявки
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateStatusTicketResponse> Handle(UpdateStatusTicketRequest request, CancellationToken cancellationToken)
    {
        var ticket = _repositoryTicket.FindById(request.TicketId);

        ticket.TicketStatusType = request.TicketStatusType;

        var res = _repositoryTicket.Update(ticket);
        
        if (res != 0) 
            return new UpdateStatusTicketResponse() {Success = true};
        else
            return new UpdateStatusTicketResponse() {Success = false, ErrorMessage = ""};
    }
}