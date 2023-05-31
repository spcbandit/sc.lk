using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Handlers.Templates;

public class GetTemplateByIdHandler: IRequestHandler<GetTemplateByIdRequest, GetTemplateByIdResponse>
{
    /// <summary>
    /// Получение шаблона по ID
    /// </summary>
    /// <param name="repositoryTemplate"></param>
    public GetTemplateByIdHandler()
    {
    }

    /// <summary>
    /// Получение шаблона по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetTemplateByIdResponse> Handle(GetTemplateByIdRequest request, CancellationToken cancellationToken)
    {

        if (true)
            return new GetTemplateByIdResponse() {Success = true};
        else
            return new GetTemplateByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetTemplate};
    }
}