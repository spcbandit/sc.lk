using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Admin;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Handlers.Admin;

public class DeactivateLicenseRequestHandler: IRequestHandler<DeactivateLicenseRequest, DeactivateLicenseResponse>
{
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;
    private readonly IISClient _isClient;

    /// <summary>
    /// DeleteLicenseHandler
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public DeactivateLicenseRequestHandler(
        IBillingServiceAdaptor billingServiceAdaptor, 
        IISClient isClient)
    {
        _billingServiceAdaptor = billingServiceAdaptor ??
                                 throw new ArgumentException(
                                     nameof(billingServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
    }

    /// <summary>
    /// DeleteLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeactivateLicenseResponse> Handle(DeactivateLicenseRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceToken.JSON;

        var res = await _billingServiceAdaptor.DeactivateLicenseAsync(request.LicenseId);
        
        if (res != Guid.Empty)
            return new DeactivateLicenseResponse() {Success = true};
        else
            return new DeactivateLicenseResponse() {Success = false, ErrorMessage = MessageResource.FailedDeactivateLicense};
    }
}