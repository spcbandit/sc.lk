using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.DistributivesVersions;
using SC.LK.Application.Domains.Responses.DistributivesVersions;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Handlers.GetDistributives;

public class GetDistributivesVersionsHandler:IRequestHandler<GetDistributivesVersionsRequest, GetDistributivesVersionsResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;

    public GetDistributivesVersionsHandler(IRepositoryConfigurationServiceAdaptor adaptor, IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper;
    }

    public async Task<GetDistributivesVersionsResponse> Handle(GetDistributivesVersionsRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;

        var agentVersion = await _adaptor.GetAgentDistributiveVersion(request);
        var map1 = _mapper.Map<DistributivesView>(agentVersion);
        var terminalVersion = await _adaptor.GetTerminalDistributiveVersion(request);
        var map2 = _mapper.Map<DistributivesView>(terminalVersion);
        
        if (agentVersion != null && terminalVersion !=null)
        {
            return new GetDistributivesVersionsResponse() 
                { 
                    Success = true, 
                    TerminalVersion = map2.Version, 
                    AgentVersion = map1.Version,
                    TerminalDistributiveId = map2.DistributiveId,
                    AgentDistributiveId = map1.DistributiveId
                };
        }
       
       


        return new GetDistributivesVersionsResponse() { Success = false };
    }
}