using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Handlers.Contractors;

public class GetContractorNameByIdHandler: IRequestHandler<GetContractorNameByIdRequest, GetContractorNameByIdResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly ILogger<GetContractorNameByIdHandler> _logger;

    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="repositoryUser"></param>
    public GetContractorNameByIdHandler( IRepository<ContractorEntity> repositoryContractor, ILogger<GetContractorNameByIdHandler> logger)
    {
        _repositoryContractor = repositoryContractor ?? throw new ArgumentException(nameof(repositoryContractor));
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into GetContractorNameByIdHandler");
    }
    
    /// <summary>
    /// Получение контагентов по UserId
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetContractorNameByIdResponse> Handle(GetContractorNameByIdRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hello, this is the index!");
        var contractor = _repositoryContractor.FindById(request.ContractorId);
        
        if (contractor != null)
            return new GetContractorNameByIdResponse() {Success = true, Name = contractor.Name};
        else
            return new GetContractorNameByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetContractors};
    }
}