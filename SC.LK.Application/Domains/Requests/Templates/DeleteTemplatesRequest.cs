using MediatR;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Domains.Requests.Templates;

public class DeleteTemplatesRequest : IRequest<DeleteTemplatesResponse>
{
    /// <summary>
    /// TemplateId
    /// </summary>
    public Guid TemplateId { get; set; }
}