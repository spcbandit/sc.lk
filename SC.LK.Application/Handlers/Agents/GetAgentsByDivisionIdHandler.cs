using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Responses.Agents;

namespace SC.LK.Application.Handlers.Agents;

public class GetAgentsByDivisionIdHandler: IRequestHandler<GetAgentsByDivisionIdRequest, GetAgentsByDivisionIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _rcClient;
    private readonly IMapper _mapper;
    private readonly IISClient _iisClient;

    /// <summary>
    /// GetAgentsByContrAgentIdHandler
    /// </summary>
    /// <param name="rcClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public GetAgentsByDivisionIdHandler(IRepositoryConfigurationServiceAdaptor rcClient, IMapper mapper, IISClient iisClient)
    {
        _rcClient = rcClient ?? throw new ArgumentException(nameof(rcClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<GetAgentsByDivisionIdResponse> Handle(GetAgentsByDivisionIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _rcClient.AuthHeader = serviceToken.JSON;
        
        var responseAgentsId = await _rcClient.GetAgentsByDivisionId(request.DivisionId);
        
        if (responseAgentsId != null)
        {
            var res = _mapper.Map<AgentsViewDto>(responseAgentsId);
            return new GetAgentsByDivisionIdResponse() {Success = true, Agents = res};
        }
        else
            return new GetAgentsByDivisionIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetAgentsByContragentId};
    }
}