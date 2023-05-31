using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Notification;

public class GetNotificationResponse:BaseResponse
{
    public List<NotificationEntity> Notifications { get; set; }
}