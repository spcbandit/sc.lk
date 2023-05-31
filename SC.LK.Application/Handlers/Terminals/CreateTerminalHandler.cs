using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class CreateTerminalHandler: IRequestHandler<CreateTerminalRequest, CreateTerminalResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public CreateTerminalHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient isClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));;
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));;
    }
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateTerminalResponse> Handle(CreateTerminalRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var terminal = await _repositoryConfigurationServiceAdaptor.AddTerminalAsync(request.Terminal);

        if(terminal != null)
            return new CreateTerminalResponse() {Success = true};
        else
            return new CreateTerminalResponse() {Success = false, ErrorMessage = MessageResource.FailedDeleteTerminal};
    }
}