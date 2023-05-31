using MediatR;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Domains.Requests.Market;

public class GetTemplatesByContragentRequest:IRequest<GetTemplatesByContragentResponse>
{
    public Guid ContragentId { get; set; }
}