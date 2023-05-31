using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

public class CreateBusinessProcessResponse : BaseResponse
{
    public Guid IdProcess { get; set; }
}