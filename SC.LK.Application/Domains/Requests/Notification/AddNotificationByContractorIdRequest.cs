using MediatR;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Domains.Requests.Notification;

public class AddNotificationByContractorIdRequest : IRequest<AddNotificationByContractorIdResponse>
{
    public string Text { get; set; }
    public string Header { get; set; }
    public DateTime Expire { get; set; }
    public int Read { get; set; }
    public int Importance { get; set; }
    public Guid? ContractorId { get; set; }
}