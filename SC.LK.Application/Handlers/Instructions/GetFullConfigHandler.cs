using System.Text.Json;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SC.LK.Application.Handlers.Instructions;

public class GetFullConfigHandler:IRequestHandler<GetFullConfigRequest, GetFullConfigResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public GetFullConfigHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient,IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public async Task<GetFullConfigResponse> Handle(GetFullConfigRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetFullConfig();
        if (res != null)
        {
            return new GetFullConfigResponse() { FullConfig = res, Success = true};
        }

        return new GetFullConfigResponse() { Success = false};
    }
}