using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class GetTerminalsByContractorIdHandler: IRequestHandler<GetTerminalsByContractorIdRequest, GetTerminalsByContractorIdResponse>
{

    private readonly IMapper _mapper;
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    private readonly IRepository<DivisionEntity> _repositoryDivision;

    /// <summary>
    /// Получение терминала по ID
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public GetTerminalsByContractorIdHandler(IMapper mapper, IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient, IRepository<DivisionEntity> repositoryDivision)
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
    public async Task<GetTerminalsByContractorIdResponse> Handle(GetTerminalsByContractorIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var terminals = await _repositoryConfigurationServiceAdaptor.GetTerminalsByKontragentIdAsync(request.ContractorId);
        var Configuration =
            await _repositoryConfigurationServiceAdaptor.GetConfigurationByKontragentIdAsync(request.ContractorId);
        var terminalsDto = _mapper.Map<TerminalsByIdDto>(terminals);

        foreach (var terminal in terminalsDto.Terminals)
        {
            if (terminal.AgentId != Guid.Empty)
            {
                var agent = await _repositoryConfigurationServiceAdaptor.GetAgentByAgentIdAsync(terminal.AgentId);
                terminal.AgentName = agent.HostName;
            }
            if (terminal.ConfigurationId != Guid.Empty )
            {
                terminal.ConfigurationName = Configuration
                    .FirstOrDefault(x => x.ConfigurationId == terminal.ConfigurationId)?
                    .ConfigurationName;
            }
            if (terminal.DivisionId != Guid.Empty)
            {
                var div = _repositoryDivision.Get(x=>x.Id == terminal.DivisionId).FirstOrDefault();
                terminal.DivisionName = div.Name;
            }
        }
        if(terminalsDto.Terminals != null)
            return new GetTerminalsByContractorIdResponse() {Success = true, Terminals = terminalsDto};
        else
            return new GetTerminalsByContractorIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetTerminal};
    }
}