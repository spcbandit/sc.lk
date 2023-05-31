using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Templates;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Handlers.Templates;

public class CreateTemplatesHandler: IRequestHandler<CreateTemplatesRequest, CreateTemplatesResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IMapper _mapper;

    /// <summary>
    /// Создать шаблон
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public CreateTemplatesHandler(IRepository<ContractorEntity> repositoryContractor, IMapper mapper)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));

    }

    /// <summary>
    /// Создать шаблон
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateTemplatesResponse> Handle(CreateTemplatesRequest request, CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor.FindById(request.ContractorId);

        var res = _repositoryContractor.Update(contractor);
        
        if (contractor != null)
        {
            var contractorDto = _mapper.Map<ContractorDto>(contractor);
            return new CreateTemplatesResponse() {Success = true, Contractor = contractorDto};
        }
        else
            return new CreateTemplatesResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateTemplate};
    }
}