using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.InternalConnectors.BillingService;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Handlers.TerminalLicense;

public class UpdateLicenseHandler: IRequestHandler<UpdateLicenseRequest, UpdateLicenseResponse>
{
    private readonly IMapper _mapper;
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;
    private readonly IISClient _isClient;

    /// <summary>
    /// UpdateLicenseHandler
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public UpdateLicenseHandler(IMapper mapper,
        IBillingServiceAdaptor billingServiceAdaptor, 
        IISClient isClient)
    {
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _billingServiceAdaptor = billingServiceAdaptor ??
                                 throw new ArgumentException(
                                     nameof(billingServiceAdaptor));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
    }

    /// <summary>
    /// UpdateLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateLicenseResponse> Handle(UpdateLicenseRequest request,
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
            LicenseId = request.LicenseId,
            SubscriptionsEnd = request.SubscriptionsEnd,
            TerminalId = request.TerminalId,
            UpdatedBy = request.UpdatedBy,
            LicenceType = request.LicenceType
        };
        
        var res = await _billingServiceAdaptor.UpdateLicenseAsync(request.LicenseId, license);
        
        if (res != null)
            return new UpdateLicenseResponse() {Success = true};
        else
            return new UpdateLicenseResponse() {Success = false, ErrorMessage = "Error"};
      
    }
}