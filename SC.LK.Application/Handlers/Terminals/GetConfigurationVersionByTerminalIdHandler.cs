using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class GetConfigurationVersionByTerminalIdHandler: IRequestHandler<GetConfigurationVersionByTerminalIdRequest, GetConfigurationVersionByTerminalIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public GetConfigurationVersionByTerminalIdHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient, IMapper mapper)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetConfigurationVersionByTerminalIdResponse> Handle(GetConfigurationVersionByTerminalIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var configuration = await _repositoryConfigurationServiceAdaptor.GetConfigurationVervionByTerminalIdAsync(request.TerminalId);

        var res = _mapper.Map<ConfigurationVersionSignViewDto>(configuration);
        
        if(configuration != null)
            return new GetConfigurationVersionByTerminalIdResponse() {Success = true, };
        else
            return new GetConfigurationVersionByTerminalIdResponse() {Success = false, ErrorMessage = MessageResource.FailedDeleteTerminal};
    }
}