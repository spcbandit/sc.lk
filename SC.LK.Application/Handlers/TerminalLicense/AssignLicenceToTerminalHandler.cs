using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Responses.TerminalLicense;

namespace SC.LK.Application.Handlers.TerminalLicense;

public class AssignLicenceToTerminalHandler: IRequestHandler<AssignLicenceToTerminalRequest, AssignLicenceToTerminalResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationService;
    private readonly IISClient _isClient;

    /// <summary>
    /// GetLicenseHandler
    /// </summary>
    /// <param name="repositoryDivision"></param>
    /// <param name="cloudApiServiceAdaptor"></param>
    /// <param name="iisClient"></param>
    public AssignLicenceToTerminalHandler(
        IRepositoryConfigurationServiceAdaptor repositoryConfigurationService, 
        IISClient isClient)
    {
        _repositoryConfigurationService = repositoryConfigurationService ??
                                          throw new ArgumentException(
                                              nameof(repositoryConfigurationService));
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
    }

    /// <summary>
    /// GetLicenseHandler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<AssignLicenceToTerminalResponse> Handle(AssignLicenceToTerminalRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _isClient.TokenAsync(null);
        _repositoryConfigurationService.AuthHeader = serviceToken.JSON;

        var LicenceTerminal = new LicenceTerminalView()
        {
            KontragentId = request.KontragentId,
            LicenceId = request.LicenceId,
            TerminalId = request.TerminalId,
            UpdatedBy = request.UpdateBy
        };
        
        var res = await _repositoryConfigurationService.AssignLicenceToTerminalAsync(LicenceTerminal);

        if (res)
            return new AssignLicenceToTerminalResponse() {Success = true};
        else
            return new AssignLicenceToTerminalResponse() {Success = false, ErrorMessage = "Error"};
      
    }
}