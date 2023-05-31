using MediatR;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Domains.Requests.Templates;

public class GetTemplateByIdRequest : IRequest<GetTemplateByIdResponse>
{
    /// <summary>
    /// TemplateId
    /// </summary>
    public Guid TemplateId { get; set; }
}