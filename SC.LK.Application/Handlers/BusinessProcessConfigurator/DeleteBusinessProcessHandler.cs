using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class DeleteBusinessProcessHandler: IRequestHandler<DeleteBusinessProcessRequest, DeleteBusinessProcessResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public DeleteBusinessProcessHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor,
        IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteBusinessProcessResponse> Handle(DeleteBusinessProcessRequest request, CancellationToken cancellationToken)
    {
        //get token
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var res = await _repositoryConfigurationServiceAdaptor
            .DeleteBusinessProcessByBusinessProcessIdAsync(request.IdBusinessProcess);

        if (res)
            return new DeleteBusinessProcessResponse() {Success = true};
        else
            return new DeleteBusinessProcessResponse() {Success = false, ErrorMessage = MessageResource.FailedGetConfigurations}; 
    }
}