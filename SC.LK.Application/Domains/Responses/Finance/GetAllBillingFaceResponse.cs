using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Finance;

public class GetAllBillingFaceResponse : BaseResponse
{
    /// <summary>
    /// BillingFaces
    /// </summary>
    public List<BillingFaceDto>  BillingFaces { get; set; }
}