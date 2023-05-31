using MediatR;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Responses.MethodAccess;

namespace SC.LK.Application.Domains.Requests.MethodAccess;

public class AddNewMethodAccessRequest:IRequest<AddNewMethodAccessResponse>
{
    public string MethodName { get; set; }
    
}