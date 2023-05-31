using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;
using SC.LK.Application.Domains.Requests.Tools;
using SC.LK.Application.Domains.Responses.Tools;

namespace SC.LK.Application.Handlers.Tools;

public class GetBuildVersionHandler: IRequestHandler<GetBuildVersionRequest, GetBuildVersionResponse>
{
    private readonly ILogger<GetBuildVersionHandler> _logger;
    internal readonly string _version;
    /// <summary>
    /// Создание подразделения
    /// </summary>
    public GetBuildVersionHandler(ILogger<GetBuildVersionHandler> logger)
    {
        _logger = logger;
        _logger.LogDebug("Constructor");

    }
    
    /// <summary>
    /// Создание подразделения
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetBuildVersionResponse> Handle(GetBuildVersionRequest request, CancellationToken cancellationToken)
    {
        var res = Assembly.GetExecutingAssembly();
        _logger.LogInformation("GetBuildVersionHandler : " + res.FullName);
        
        if (res != null) 
            return new GetBuildVersionResponse() {Success = true, Version = res.FullName};
        else
            return new GetBuildVersionResponse() {Success = false, ErrorMessage = ""};
    }
}