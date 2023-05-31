using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Handlers.Agents;

public class GetDistributiveAgentHandler : IRequestHandler<GetDistributiveAgentRequest, FileStreamResult>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IISClient _iisClient;
    
    /// <summary>
    /// GetDistributiveAgentHandler
    /// </summary>
    /// <param name="rcClient"></param>
    /// <param name="mapper"></param>
    /// <param name="iisClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public GetDistributiveAgentHandler(IRepositoryConfigurationServiceAdaptor rcClient, IISClient iisClient)
    {
        _rcClient = rcClient ?? throw new ArgumentException(nameof(rcClient));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }
    
    /// <summary>
    /// GetDistributiveAgentHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<FileStreamResult> Handle(GetDistributiveAgentRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        
        var distributive = await _rcClient.GetDistributiveAgentAsync();
        return distributive;
        /*if (distributive == null)
            return null;

        var memoryStream = new MemoryStream(distributive);
        
        return new FileStreamResult(memoryStream, "application/octet-stream")
        {
            FileDownloadName = "SC.SiteAgent.msi"
        };*/
    }
}