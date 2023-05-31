using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class AddTerminalsToDivisionHandler: IRequestHandler<AddTerminalsToDivisionRequest, AddTerminalsToDivisionResponse>
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
    public AddTerminalsToDivisionHandler(IMapper mapper, IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient)
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
    public async Task<AddTerminalsToDivisionResponse> Handle(AddTerminalsToDivisionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        List<TerminalsToDivisionDto> resp = new List<TerminalsToDivisionDto>(); 

        foreach (var terminalId in request.TerminalsId)
        {
            var terminal = await _repositoryConfigurationServiceAdaptor.GetTerminalByTerminalIdAsync(terminalId);
            terminal.DivisionId = request.DivisionId;
            
            var res =  await _repositoryConfigurationServiceAdaptor.UpdateTerminalAsync(terminalId,terminal);
            resp.Add(res != Guid.Empty
                ? new TerminalsToDivisionDto() {Success = true, TerminalId = terminal.TerminalId ?? Guid.Empty}
                : new TerminalsToDivisionDto() {Success = false, TerminalId = terminal.TerminalId ?? Guid.Empty});
        }
        
        if (resp.Count != 0) 
            return new AddTerminalsToDivisionResponse() {Success = true, TerminalsToDivision = resp};
        else
            return new AddTerminalsToDivisionResponse() {Success = false, ErrorMessage = "Error"};
        /*var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        List<TerminalsToDivisionDto> resp = new List<TerminalsToDivisionDto>(); 

        foreach (var terminal in request.Terminals)
        {
            terminal.DivisionId = request.DivisionId;
            var res =  await _repositoryConfigurationServiceAdaptor.UpdateTerminalAsync(terminal.TerminalId, terminal);
            resp.Add(res != Guid.Empty
                ? new TerminalsToDivisionDto() {Success = true, TerminalId = terminal.TerminalId}
                : new TerminalsToDivisionDto() {Success = false, TerminalId = terminal.TerminalId});
        }
        
        if (resp.Count != 0) 
            return new AddTerminalsToDivisionResponse() {Success = true, TerminalsToDivision = resp};
        else
            return new AddTerminalsToDivisionResponse() {Success = false, ErrorMessage = "Error"};*/
    }
}