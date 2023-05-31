using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.Agents;
using SC.LK.Application.Domains.Responses.Terminals;

namespace SC.LK.Application.Handlers.Terminals;

public class GetDistributiveTerminalHandler : IRequestHandler<GetDistributiveTerminalRequest, GetDistributiveTerminalResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// GetDistributiveTerminalHandler
    /// </summary>
    /// <param name="rcClient"></param>
    /// <param name="mapper"></param>
    /// <param name="iisClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public GetDistributiveTerminalHandler(IRepositoryConfigurationServiceAdaptor rcClient, IISClient iisClient)
    {
        _rcClient = rcClient ?? throw new ArgumentException(nameof(rcClient));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }
    
    /// <summary>
    /// GetDistributiveTerminalHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<GetDistributiveTerminalResponse> Handle(GetDistributiveTerminalRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        

        var link = await _rcClient.GetDistributiveTerminalAsync(); 
        
        if (link == null)
            return null;
        
        
        return new GetDistributiveTerminalResponse()
        {
            Success = true, Link = link
        };
    }
}