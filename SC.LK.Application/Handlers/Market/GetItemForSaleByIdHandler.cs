using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Handlers.Market;

public class GetItemForSaleByIdHandler:IRequestHandler<GetItemForSaleByIdRequest,GetItemForSaleByIdResponse>
{
    private readonly IBillingServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;

    public GetItemForSaleByIdHandler(IBillingServiceAdaptor adaptor, IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper;
    }

    public async Task<GetItemForSaleByIdResponse> Handle(GetItemForSaleByIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetItemForSaleByItemForSaleId(request.ItemId);
        var map = _mapper.Map<ItemForSaleResponse>(res);
        if (map != null)
        {
            return new GetItemForSaleByIdResponse() { Success = true, ItemForSaleResponse = map};
        }

        return new GetItemForSaleByIdResponse() { Success = false };
    }
}