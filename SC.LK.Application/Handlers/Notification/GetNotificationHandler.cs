using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Handlers.Notification;

public class GetNotificationHandler:IRequestHandler<GetNotificationRequest, GetNotificationResponse>
{
    private readonly IRepository<NotificationEntity> _repository;


    public GetNotificationHandler(IRepository<NotificationEntity> repository)
    {
        _repository = repository;
    }

    public async Task<GetNotificationResponse> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get(x => x.Expire >= DateTime.Now && x.ContractorId == Guid.Empty || x.ContractorId == null).ToList();
        return new GetNotificationResponse() { Notifications = get, Success = true };
      
    }
}