using MediatR;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Domains.Requests.Notification;

public class GetNotificationByContractorIdRequest : IRequest<GetNotificationByContractorIdResponse>
{
    public Guid ContractorId { get; set; }
}