using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class SaveTerminalHandler : IRequestHandler<UpdateTerminalRequest, UpdateTerminalResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    
    /// <summary>
    /// Сохранение терминала
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public SaveTerminalHandler(IMapper mapper, IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));    }
    
    /// <summary>
    /// Сохранение терминала
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateTerminalResponse> Handle(UpdateTerminalRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var terminal =await _repositoryConfigurationServiceAdaptor.UpdateTerminalAsync(request.TerminalId, request.Terminal);

        if (terminal != null) 
            return new UpdateTerminalResponse() {Success = true};
        else
            return new UpdateTerminalResponse() {Success = false, ErrorMessage = MessageResource.FailedGetTerminals};
    }
}