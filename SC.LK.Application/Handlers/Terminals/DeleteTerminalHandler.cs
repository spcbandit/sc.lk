using JetBrains.Annotations;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.TerminalLicense;
using SC.LK.Application.Domains.Requests.Terminals;
using SC.LK.Application.Domains.Responses.TerminalLicense;
using SC.LK.Application.Domains.Responses.Terminals;
using SC.LK.Application.Handlers.TerminalLicense;

namespace SC.LK.Application.Handlers.Terminals;

public class DeleteTerminalHandler: IRequestHandler<DeleteTerminalRequest, DeleteTerminalResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _isClient;
    private readonly IBillingServiceAdaptor _billingServiceAdaptor;

    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="repositoryTerminal"></param>
    public DeleteTerminalHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, 
        IISClient isClient, 
        IBillingServiceAdaptor billingServiceAdaptor)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));;
        _isClient = isClient ?? throw new ArgumentException(nameof(isClient));;
        _billingServiceAdaptor = billingServiceAdaptor ??
                                 throw new ArgumentException(
                                     nameof(billingServiceAdaptor));
    }
    
    /// <summary>
    /// Удаление терминала
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteTerminalResponse> Handle(DeleteTerminalRequest request, CancellationToken cancellationToken)
    {
        var serviceTokenLicence = await _isClient.TokenAsync(null);
        _billingServiceAdaptor.AuthHeader = serviceTokenLicence.JSON;
        bool res = false;
        res = request.LicenceId == null;

        if (!res)
        {
            var LicenceTerminal = new LicenceTerminalView()
            {
                KontragentId = request.KontragentId,
                LicenceId = request.LicenceId.Value,
                TerminalId = request.TerminalId,
                UpdatedBy = request.UpdateBy
            };
            res = await _billingServiceAdaptor.ReleaseLicenceAsync(LicenceTerminal);
        }

        if (res)
        {
            var serviceToken = await _isClient.TokenAsync(null);
            _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
            var terminal =
                await _repositoryConfigurationServiceAdaptor.DeleteAsync(request.TerminalId, request.UpdateBy);

            if (terminal != null)
                return new DeleteTerminalResponse() {Success = true};
            else
                return new DeleteTerminalResponse()
                    {Success = false, ErrorMessage = MessageResource.FailedDeleteTerminal};
        }
        else
        {
            return new DeleteTerminalResponse()
                {Success = false, ErrorMessage = "Не удалось отвязать лицензию, удаление невозможно"};
        }
    }
}