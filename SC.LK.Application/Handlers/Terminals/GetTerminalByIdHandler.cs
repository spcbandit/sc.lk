using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class GetTerminalByIdHandler: IRequestHandler<GetTerminalByIdRequest, GetTerminalByIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IMapper _mapper;
    private readonly IISClient _isClient;
    
    /// <summary>
    /// Получение терминала по ID
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public GetTerminalByIdHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IMapper mapper, IISClient isClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
    }
    
    /// <summary>
    /// Получение терминала по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetTerminalByIdResponse> Handle(GetTerminalByIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var terminal =await _repositoryConfigurationServiceAdaptor.GetTerminalByTerminalIdAsync(request.TerminalId);
        var terminalDto = _mapper.Map<TerminalDto>(terminal);
        if(terminal != null)
            return new GetTerminalByIdResponse() {Success = true, Terminal = terminalDto};
        else
            return new GetTerminalByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetTerminal};
    }
    
}