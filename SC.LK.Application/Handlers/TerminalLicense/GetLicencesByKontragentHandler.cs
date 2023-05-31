using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Handlers.TerminalLicense;

public class GetLicencesByKontragentHandler: IRequestHandler<GetLicencesByKontragentRequest, GetLicencesByKontragentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;
    private readonly IISClient _isClient;

    /// <summary>
    /// DeleteLicenseHandler
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public GetLicencesByKontragentHandler(IMapper mapper,
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
    /// DeleteLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetLicencesByKontragentResponse> Handle(GetLicencesByKontragentRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceToken.JSON;

        var res = await _billingServiceAdaptor.GetLicencesByKontragentAsync(request.KontragentId);

        var LicenseView = _mapper.Map<List<LicenseViewDto>>(res);
        
        if (res != null)
            return new GetLicencesByKontragentResponse() {Success = true, LicenseView = LicenseView};
        else
            return new GetLicencesByKontragentResponse() {Success = false, ErrorMessage = "Error"};
      
    }
}