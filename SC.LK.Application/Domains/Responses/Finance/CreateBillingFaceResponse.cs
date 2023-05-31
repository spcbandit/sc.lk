using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Finance;

public class CreateBillingFaceResponse : BaseResponse
{
    /// <summary>
    /// BillingFace
    /// </summary>
    public BillingFaceDto BillingFace { get; set; }
}