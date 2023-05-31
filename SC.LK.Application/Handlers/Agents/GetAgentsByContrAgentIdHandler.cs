using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;
using IMapper = AutoMapper.IMapper;

namespace SC.LK.Application.Handlers.Agents;

public class GetAgentsByContrAgentIdHandler : IRequestHandler<GetAgentsByContragentIdRequest, GetAgentsByContragentIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IMapper _mapper;
    private readonly IISClient _iisClient;

    /// <summary>
    /// GetAgentsByContrAgentIdHandler
    /// </summary>
    /// <param name="rcClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public GetAgentsByContrAgentIdHandler(IRepositoryConfigurationServiceAdaptor rcClient, IMapper mapper, IISClient iisClient)
    {
        _rcClient = rcClient ?? throw new ArgumentException(nameof(rcClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// GetAgentsByContrAgentIdHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<GetAgentsByContragentIdResponse> Handle(GetAgentsByContragentIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        
        var responseAgents = await _rcClient.GetAgentsByKontragentId(request.ContragentId);
        
        if (responseAgents != null)
        {
            var res = _mapper.Map<AgentsViewDto>(responseAgents);
            return new GetAgentsByContragentIdResponse() {Success = true, Agents = res};
        }
        else
            return new GetAgentsByContragentIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetAgentsByContragentId};
    }
}