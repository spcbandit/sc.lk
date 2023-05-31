using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.Requests.Admin;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Handlers.Admin;

public class AddLicenseHandler: IRequestHandler<AddLicenseRequest, AddLicenseResponse>
{
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;
    private readonly IISClient _isClient;

    /// <summary>
    /// BuyLicenseHandler
    /// </summary>
    public AddLicenseHandler(IBillingServiceAdaptor billingServiceAdaptor, 
        IISClient isClient)
    {
        _billingServiceAdaptor = billingServiceAdaptor ??
                                 throw new ArgumentException(
                                     nameof(billingServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
    }

    /// <summary>
    /// BuyLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<AddLicenseResponse> Handle(AddLicenseRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceToken.JSON;

        var license = new LicenseView()
        {
            Description = request.Description,
            Provider = request.Provider,
            IsActive = request.IsActive,
            KontragentId = request.KontragentId,
            SubscriptionsEnd = request.SubscriptionsEnd,
            TerminalId = request.TerminalId,
            UpdatedBy = request.UpdatedBy,
            LicenceType = request.LicenceType,
            LicenseId = Guid.Empty
        };

        var res = await _billingServiceAdaptor.AddLicenseAsync(license);
        
        if (res != Guid.Empty)
            return new AddLicenseResponse() {Success = true};
        else
            return new AddLicenseResponse() {Success = false, ErrorMessage = MessageResource.FailedAddLicense};
      
    }
}