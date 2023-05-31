using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Handlers.Templates;

public class DeleteTemplatesHandler: IRequestHandler<DeleteTemplatesRequest, DeleteTemplatesResponse>
{

    /// <summary>
    /// Удаление шаблона
    /// </summary>
    /// <param name="repositoryTemplate"></param>
    public DeleteTemplatesHandler()
    {
    }

    /// <summary>
    /// Удаление шаблона
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteTemplatesResponse> Handle(DeleteTemplatesRequest request, CancellationToken cancellationToken)
    {

        
        if (true)
            return new DeleteTemplatesResponse() {Success = true};
        else
            return new DeleteTemplatesResponse() {Success = false, ErrorMessage = MessageResource.FailedDeleteTemplate};
    }
}