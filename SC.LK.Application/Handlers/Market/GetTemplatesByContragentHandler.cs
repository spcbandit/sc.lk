using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Handlers.Market;

public class GetTemplatesByContragentHandler:IRequestHandler<GetTemplatesByContragentRequest, GetTemplatesByContragentResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;

    public GetTemplatesByContragentHandler(IRepositoryConfigurationServiceAdaptor adaptor, IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper;
    }

    public async Task<GetTemplatesByContragentResponse> Handle(GetTemplatesByContragentRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetAllTemplatesByContragentId(request.ContragentId);
        if (res != null)
        {
            return new GetTemplatesByContragentResponse() { Success = true, TemplatesList = res};
        }

        return new GetTemplatesByContragentResponse() { Success = false };
    }
}