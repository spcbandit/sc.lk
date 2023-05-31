using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Handlers.Templates;

public class GetAllTemplatesHandler : IRequestHandler<GetAllTemplatesRequest, GetAllTemplatesResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
 
    /// <summary>
    /// Полушение всех шаблонов 
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllTemplatesHandler(IRepository<ContractorEntity> repositoryContractor)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
    }

    /// <summary>
    /// Полушение всех шаблонов 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllTemplatesResponse> Handle(GetAllTemplatesRequest request, CancellationToken cancellationToken)
    {
        
        if (true)
            return new GetAllTemplatesResponse() {Success = true};
        else
            return new GetAllTemplatesResponse() {Success = false, ErrorMessage =MessageResource.FailedGetTemplates};
    }
}