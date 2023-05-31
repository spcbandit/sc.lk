using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Tickets;
using SC.LK.Application.Domains.Responses.Tickets;

namespace SC.LK.Application.Handlers.Tickets;

public class GetAllTicketsHandler : IRequestHandler<GetAllTicketsRequest, GetAllTicketsResponse>
{
    private readonly IRepository<TicketEntity> _repositoryTicket;
    private readonly IRepository<UserEntity> _repositoryUser;

    public GetAllTicketsHandler(IRepository<TicketEntity> repositoryTicket, IRepository<UserEntity> repositoryUser)
    {
        _repositoryTicket = repositoryTicket;
        _repositoryUser = repositoryUser;
    }

    public async Task<GetAllTicketsResponse> Handle(GetAllTicketsRequest request, CancellationToken cancellationToken)
    {
        var tickets = new List<TicketEntity>();
        if (request.ContractorId == Guid.Parse("00000000-0000-0000-0000-000000000001"))
        {
            tickets = _repositoryTicket.Get().ToList();
        }
        else
        {
            tickets = _repositoryTicket.Get(x => x.FromContragent == request.ContractorId).ToList();
        }

        return new GetAllTicketsResponse() {Success = true, Tickets = tickets};
    }
}