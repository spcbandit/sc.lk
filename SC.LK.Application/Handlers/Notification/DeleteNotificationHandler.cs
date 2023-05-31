using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Handlers.Notification;

public class DeleteNotificationHandler:IRequestHandler<DeleteNotificationRequest,DeleteNotificationResponse>
{
    private readonly IRepository<NotificationEntity> _repository;

    public DeleteNotificationHandler(IRepository<NotificationEntity> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteNotificationResponse> Handle(DeleteNotificationRequest request, CancellationToken cancellationToken)
    {
        var get = _repository.Get(x => x.Id == request.Id).FirstOrDefault();
        if (get != null)
        {
            var delete = _repository.Remove(get);
            return new DeleteNotificationResponse() { Success = true };
        }

        return new DeleteNotificationResponse() { Success = false };
    }
}