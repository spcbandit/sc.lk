using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Handlers.Templates;

public class UpdateTemplateByIdHandler: IRequestHandler<UpdateTemplateByIdRequest, UpdateTemplateByIdResponse>
{
    
    
    /// <summary>
    /// Обновление шаблона
    /// </summary>
    /// <param name="repositoryTemplate"></param>
    public UpdateTemplateByIdHandler()
    {
    }

    /// <summary>
    /// Обновление шаблона
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateTemplateByIdResponse> Handle(UpdateTemplateByIdRequest request, CancellationToken cancellationToken)
    {
       
        if (true)
            return new UpdateTemplateByIdResponse() {Success = true};
        else
            return new UpdateTemplateByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateTemplate};
    }
}