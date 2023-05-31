using MediatR;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class DeleteMethodAccessRequest:IRequest<DeleteMethodAccessResponse>
{
    public Guid Id { get; set; }
}