using MediatR;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class GetMethodAccessRequest:IRequest<GetMethodAccessResponse>
{
    public Guid Id { get; set; }
}