using System.Reflection;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Handlers.Tickets;

public class CreateTicketHandler: IRequestHandler<CreateTicketRequest, CreateTicketResponse>
{
    internal readonly IRepository<TicketEntity> _repositoryTicket;

    /// <summary>
    /// Создание подразделения
    /// </summary>
    public CreateTicketHandler(IRepository<TicketEntity> ticket)
    {
        _repositoryTicket = ticket;
    }
    
    /// <summary>
    /// Создание подразделения
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateTicketResponse> Handle(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var searchTicket = _repositoryTicket
            .Get(x => x.TicketType == TicketType.Partner && x.FromContragent == request.FromContragent)
            .FirstOrDefault();
        if (searchTicket != null)
        {
            return new CreateTicketResponse()
                {Success = false, ErrorMessage = "Заявка уже зарегистрирована и находится в обработке"};
        }

        var res = _repositoryTicket.Create(new TicketEntity()
        {
            Message = request.Message,
            FromContragent = request.FromContragent,
            FromUser = request.FromUser,
            TicketType = request.TicketType,
            TicketStatusType = request.TicketStatusType
        });
        
        if (res != 0) 
            return new CreateTicketResponse() {Success = true};
        else
            return new CreateTicketResponse() {Success = false, ErrorMessage = ""};
    }
}