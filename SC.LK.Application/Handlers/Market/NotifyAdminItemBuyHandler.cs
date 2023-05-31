using System.Text;
using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.Requests.Market;
using SC.LK.Application.Domains.Responses.Market;

namespace SC.LK.Application.Handlers.Market;

public class NotifyAdminItemBuyHandler:IRequestHandler<NotifyAdminItemBuyRequest,NotifyAdminItemBuyResponse>
{
    private readonly IBillingServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMailKit _mailKit;

    public NotifyAdminItemBuyHandler(IBillingServiceAdaptor adaptor, IISClient iisClient, IMailKit mailKit)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mailKit = mailKit;
    }

    public async Task<NotifyAdminItemBuyResponse> Handle(NotifyAdminItemBuyRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var sb = new StringBuilder($"Поступил заказ от {request.ContragentName}:");
        foreach (var i in request.Items)
        {
            var getItem = await _adaptor.GetItemForSaleByItemForSaleId(i.ItemGuid);
            sb.Append($"<br> Лицензия: 1 год в количестве - {i.Quantity} / Название продукта:{getItem.itemName},");
        }
        
        await _mailKit.NotifyAdmin(null, sb.ToString());
        return new NotifyAdminItemBuyResponse() { Success = true };
    }
}