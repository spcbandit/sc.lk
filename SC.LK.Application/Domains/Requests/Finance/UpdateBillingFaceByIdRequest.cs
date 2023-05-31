using MediatR;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Domains.Requests.Finance;

public class UpdateBillingFaceByIdRequest : IRequest<UpdateBillingFaceByIdResponse>
{
    /// <summary>
    /// BillingFaceId
    /// </summary>
    public Guid BillingFaceId { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// ИНН
    /// </summary>
    public string INN { get; set; }
    
    /// <summary>
    /// КПП
    /// </summary>
    public string KPP { get; set; }
}