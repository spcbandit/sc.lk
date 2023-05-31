using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.MethodAccess;

public class GetAllMethodsResponse:BaseResponse
{
    public List<MethodAccessTypeEntity> MethodAccess { get; set; }
}