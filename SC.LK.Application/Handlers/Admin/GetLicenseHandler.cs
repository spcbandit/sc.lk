using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.Admin;
using SC.LK.Application.Domains.Responses.Admin;

namespace SC.LK.Application.Handlers.Admin;

public class GetLicenseHandler : IRequestHandler<GetLicenseRequest, GetLicenseResponse>
{
    private readonly IMapper _mapper;
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;
    private readonly IISClient _isClient;

    /// <summary>
    /// GetLicenseHandler
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public GetLicenseHandler(IMapper mapper,
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
    /// GetLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetLicenseResponse> Handle(GetLicenseRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceToken.JSON;

        var res = await _billingServiceAdaptor.GetLicenseByIdAsync(request.LicenseId);

        if (res != null)
        {
            var licenseMap = _mapper.Map<LicenseViewDto>(res);
            return new GetLicenseResponse() {Success = true, LicenseViewDto = licenseMap};
        }
        else
            return new GetLicenseResponse() {Success = false, ErrorMessage = MessageResource.FailedGetLicense};
    }
}