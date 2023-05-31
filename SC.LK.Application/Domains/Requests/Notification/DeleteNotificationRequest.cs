using MediatR;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Domains.Requests.Notification;

public class DeleteNotificationRequest:IRequest<DeleteNotificationResponse>
{
    public Guid Id { get; set; }
}