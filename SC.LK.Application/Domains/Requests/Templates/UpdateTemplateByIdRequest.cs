using MediatR;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Domains.Requests.Templates;

public class UpdateTemplateByIdRequest : IRequest<UpdateTemplateByIdResponse>   
{
    /// <summary>
    /// TemplateId
    /// </summary>
    public Guid TemplateId { get; set; }
}