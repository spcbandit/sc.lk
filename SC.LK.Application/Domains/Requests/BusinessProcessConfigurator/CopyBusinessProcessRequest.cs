using MediatR;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class CopyBusinessProcessRequest : IRequest<CopyBusinessProcessResponse>
{
    public Guid IdBusinessProcess { get; set; } 
}