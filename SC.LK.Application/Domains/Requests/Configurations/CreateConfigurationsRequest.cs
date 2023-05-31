using MediatR;
using SC.LK.Application.Domains.Responses.Configurations;

namespace SC.LK.Application.Domains.Requests.Configurations;

public class CreateConfigurationsRequest : IRequest<CreateConfigurationsResponse>
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
    /// Description
    /// </summary>
    public string? Description { get; set; }
}