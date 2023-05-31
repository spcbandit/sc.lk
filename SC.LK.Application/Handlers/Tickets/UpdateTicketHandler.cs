using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Handlers.Tickets;

public class UpdateTicketHandler: IRequestHandler<UpdateTicketRequest, UpdateTicketResponse>
{
    internal readonly IRepository<TicketEntity> _repositoryTicket;

    /// <summary>
    /// Обновить заявку
    /// </summary>
    public UpdateTicketHandler(IRepository<TicketEntity> ticket)
    {
        _repositoryTicket = ticket;
    }
    
    /// <summary>
    /// Обновить заявку
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateTicketResponse> Handle(UpdateTicketRequest request, CancellationToken cancellationToken)
    {
        var ticket = _repositoryTicket.FindById(request.TicketId);

        ticket.Message = request.Message;
        ticket.FromContragent = request.FromContragent;
        ticket.FromUser = request.FromUser;
        ticket.TicketType = request.TicketType;
        ticket.TicketStatusType = request.TicketStatusType;

        var res = _repositoryTicket.Update(ticket);
        
        if (res != 0) 
            return new UpdateTicketResponse() {Success = true};
        else
            return new UpdateTicketResponse() {Success = false, ErrorMessage = ""};
    }
}