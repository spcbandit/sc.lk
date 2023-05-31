using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Handlers.Market;

public class CreateBPByItemForSaleIdHandler:IRequestHandler<CreateBPByItemForSaleIdRequest,CreateBPByItemForSaleIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _client;
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;

    public CreateBPByItemForSaleIdHandler(IRepositoryConfigurationServiceAdaptor adaptor, IISClient client, IBillingServiceAdaptor billingServiceAdaptor)
    {
        _adaptor = adaptor;
        _client = client;
        _billingServiceAdaptor = billingServiceAdaptor;
    }

    public async Task<CreateBPByItemForSaleIdResponse> Handle(CreateBPByItemForSaleIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _client.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var serviceTokenBill = await _client.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceTokenBill.JSON;
        var getItem = await _billingServiceAdaptor.GetItemForSaleByItemForSaleId(request.ItemId);
        var bpId = Guid.NewGuid();
        var createBP = await _adaptor.AddBusinessProcessAsync(
            new BusinessProcessView()
            {
                IsTemplate = true,
                JsonBody = getItem.itemContent,
                KontragentId = request.ContragentId,
                IsDeleted = false,
                ConfigurationVersions = new List<ConfigurationsBusinessProcessView>(),
                BusinessProcessDescription = getItem.itemDescription,
                BusinessProcessId = bpId,
                BusinessProcessName = getItem.itemName,
                TemplateId = request.ItemId,
            });
        if (createBP != Guid.Empty)
        {
            return new CreateBPByItemForSaleIdResponse() { Success = true, BusinessProcessId = bpId };
        }

        return new CreateBPByItemForSaleIdResponse() { Success = false };
    }
}