using MediatR;
using SC.LK.Application.Domains.Responses.Finance;

namespace SC.LK.Application.Domains.Requests.Finance;

public class CreateBillingFaceRequest : IRequest<CreateBillingFaceResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// INN
    /// </summary>
    public string INN { get; set; }
    
    /// <summary>
    /// KPP
    /// </summary>
    public string KPP { get; set; }
}