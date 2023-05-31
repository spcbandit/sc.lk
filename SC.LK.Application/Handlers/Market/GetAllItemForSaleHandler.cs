using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Instructions;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Handlers.Market;

public class GetAllItemForSaleHandler:IRequestHandler<GetAllItemForSaleRequest,GetAllItemForSaleResponse>
{
    private readonly IBillingServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;

    public GetAllItemForSaleHandler(IBillingServiceAdaptor adaptor, IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper;
    }

    public async Task<GetAllItemForSaleResponse> Handle(GetAllItemForSaleRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetAllItemForSale();
        var map = _mapper.Map<List<ItemForSaleResponse>>(res);
        if (map != null)
        {
            return new GetAllItemForSaleResponse() { Success = true, ItemForSaleResponse = map};
        }

        return new GetAllItemForSaleResponse() { Success = false };
    }
}