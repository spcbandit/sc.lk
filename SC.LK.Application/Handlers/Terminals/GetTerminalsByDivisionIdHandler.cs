using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class GetTerminalsByDivisionIdHandler: IRequestHandler<GetTerminalsByDivisionIdRequest, GetTerminalsByDivisionIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    private readonly IRepository<DivisionEntity> _repositoryDivision;

    
    /// <summary>
    /// Получение терминала по ID
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public GetTerminalsByDivisionIdHandler(IMapper mapper, IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient, IRepository<DivisionEntity> repositoryDivision)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
        _repositoryDivision = repositoryDivision ?? throw new ArgumentException(nameof(repositoryDivision));
    }
    
    /// <summary>
    /// Получение терминала по ID
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetTerminalsByDivisionIdResponse> Handle(GetTerminalsByDivisionIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var terminals = await _repositoryConfigurationServiceAdaptor.GetTerminalsByDivisionIdAsync(request.DivisionId); 
        
        var terminalsDto = _mapper.Map<TerminalsByIdDto>(terminals);
        var Configuration = 
            await _repositoryConfigurationServiceAdaptor.GetConfigurationByKontragentIdAsync(terminalsDto.KontragentId);
        foreach (var terminal in terminalsDto.Terminals)
        {
            
            if (terminal.AgentId != Guid.Empty)
            {
                var agent = await _repositoryConfigurationServiceAdaptor.GetAgentByAgentIdAsync(terminal.AgentId);
                terminal.AgentName = agent.HostName;
            }
            if (terminal.ConfigurationId != Guid.Empty )
            {
                terminal.ConfigurationName = Configuration.FirstOrDefault(x => x.ConfigurationId == terminal.ConfigurationId !=null)
                    .ConfigurationName;
            }
            if (terminal.DivisionId != Guid.Empty)
            {
                terminal.DivisionName = _repositoryDivision.Get(x=>x.Id == terminal.DivisionId).FirstOrDefault().Name;
            }
        }
        
        if(terminalsDto.Terminals != null)
            return new GetTerminalsByDivisionIdResponse() {Success = true, Terminals = terminalsDto};
        else
            return new GetTerminalsByDivisionIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetTerminal};
    }
}