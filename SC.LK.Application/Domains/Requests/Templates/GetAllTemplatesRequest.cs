using MediatR;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Domains.Requests.Templates;

public class GetAllTemplatesRequest : IRequest<GetAllTemplatesResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
}