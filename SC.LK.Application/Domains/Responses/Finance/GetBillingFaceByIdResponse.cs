using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Finance;

public class GetBillingFaceByIdResponse : BaseResponse
{
    /// <summary>
    /// BillingFace
    /// </summary>
    public BillingFaceDto BillingFace { get; set; }
}