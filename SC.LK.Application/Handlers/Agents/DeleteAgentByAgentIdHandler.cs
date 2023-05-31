using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;
using System;


namespace SC.LK.Application.Handlers.Agents;

public class DeleteAgentByAgentIdHandler: IRequestHandler<DeleteAgentByAgentIdRequest, DeleteAgentByAgentIdResponce>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// Создание конфигурации 
    /// </summary>
    /// <param name="repositoryConfigurationServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    /// <param name="mapper"></param>
    /// <exception cref="ArgumentException"></exception>
    public DeleteAgentByAgentIdHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient, IMapper mapper)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor;
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Создание конфигурации
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteAgentByAgentIdResponce> Handle(DeleteAgentByAgentIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var res = await _repositoryConfigurationServiceAdaptor
            .DeleteAgentByAgentId(request.AgentId);

        if (res)
            return new DeleteAgentByAgentIdResponce() { Success = true };
        else
            return new DeleteAgentByAgentIdResponce() { Success = false, ErrorMessage = "Не удалось удалить агента, проверьте наличие терминалов" };
    }
}
