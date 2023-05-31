﻿using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Handlers.TerminalLicense;

public class BindLicenceToTerminalHandler: IRequestHandler<BindLicenceToTerminalRequest, BindLicenceToTerminalResponse>
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
    public BindLicenceToTerminalHandler(IMapper mapper,
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
    public async Task<BindLicenceToTerminalResponse> Handle(BindLicenceToTerminalRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceToken.JSON;

        var License = new LicenceTerminalView()
        {
            KontragentId = request.KontragentId,
            LicenceId = request.LicenceId,
            TerminalId = request.TerminalId,
            UpdatedBy = request.UpdateBy
        };
        
        var res = await _billingServiceAdaptor.BindLicenceToTerminalAsync(License);
        
        if (res)
            return new BindLicenceToTerminalResponse() {Success = true};
        else
            return new BindLicenceToTerminalResponse() {Success = false, ErrorMessage = "Error"};
      
    }
}