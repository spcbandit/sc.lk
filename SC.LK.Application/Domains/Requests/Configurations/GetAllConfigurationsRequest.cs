using MediatR;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Domains.Requests.Configurations;

public class GetAllConfigurationsRequest : IRequest<GetAllConfigurationsResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
    
}