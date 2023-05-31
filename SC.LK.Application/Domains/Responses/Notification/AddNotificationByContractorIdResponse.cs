namespace SC.LK.Application.Domains.Responses.Notification;

public class AddNotificationByContractorIdResponse : BaseResponse
{
    public Guid Id { get; set; }
    public Guid ContractorId { get; set; }
}