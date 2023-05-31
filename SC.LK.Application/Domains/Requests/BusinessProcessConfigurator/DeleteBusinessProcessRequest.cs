using MediatR;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;

public class DeleteBusinessProcessRequest : IRequest<DeleteBusinessProcessResponse>
{
    public Guid IdBusinessProcess { get; set; } 
}