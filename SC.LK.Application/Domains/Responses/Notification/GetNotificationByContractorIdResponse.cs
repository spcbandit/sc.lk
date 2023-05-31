using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Notification;

public class GetNotificationByContractorIdResponse : BaseResponse
{
    public List<NotificationEntity> Notifications { get; set; }
}