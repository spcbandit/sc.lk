using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.MethodAccess;

public class GetMethodAccessResponse:BaseResponse
{
    public MethodAccessTypeEntity MethodAccessTypeEntity { get; set; }
}