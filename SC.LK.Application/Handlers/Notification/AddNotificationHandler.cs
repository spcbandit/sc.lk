using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Handlers.Notification;

public class AddNotificationHandler:IRequestHandler<AddNotificationRequest,AddNotificationResponse>
{
    private readonly IRepository<NotificationEntity> _repository;

    public AddNotificationHandler(IRepository<NotificationEntity> repository)
    {
        _repository = repository;
        
    }

    public async Task<AddNotificationResponse> Handle(AddNotificationRequest request, CancellationToken cancellationToken)
    {
        Guid guid = Guid.NewGuid();
        var add = new NotificationEntity()
        {
            Id = guid,
            Expire = request.Expire,
            Header = request.Header,
            Importance = request.Importance,
            Read = request.Read,
            Text = request.Text,            
        };
        var save = _repository.Create(add);
        if (save != 0)
        {
            return new AddNotificationResponse() { Success = true, Id = guid };
        }

        return new AddNotificationResponse() { Success = false, ErrorMessage = "can't save"};
    }
}