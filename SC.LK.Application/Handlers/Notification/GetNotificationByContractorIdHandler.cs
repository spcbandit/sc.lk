using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.Notification;


namespace SC.LK.Application.Handlers.Notification;

public class GetNotificationByContractorIdHandler : IRequestHandler<GetNotificationByContractorIdRequest, GetNotificationByContractorIdResponse>
{
    private readonly IRepository<NotificationEntity> _repository;

    public GetNotificationByContractorIdHandler(IRepository<NotificationEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetNotificationByContractorIdResponse> Handle(GetNotificationByContractorIdRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get(x => x.ContractorId == request.ContractorId).ToList();
        if (get != null)
        {
            return new GetNotificationByContractorIdResponse() { Notifications = get, Success = true };    
        }
        else
        {
            return new GetNotificationByContractorIdResponse() {Success = false};
        }

    }
}