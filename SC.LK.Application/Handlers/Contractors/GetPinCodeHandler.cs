using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.Contractors;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Handlers.Contractors;

public class GetPinCodeHandler : IRequestHandler<GetPincodeRequest, GetPinCodeResponse>
{
    private readonly IISClient _iisClient;

    /// <summary>
    /// GetPinCodeHandler
    /// </summary>
    /// <param name="iisClient"></param>
    /// <exception cref="ArgumentException"></exception>
    public GetPinCodeHandler(IISClient iisClient)
    {
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetPinCodeResponse> Handle(GetPincodeRequest request, CancellationToken cancellationToken)
    {
        
        var serviceToken = await _iisClient.TokenAsync(null);
        _iisClient.AuthHeader = serviceToken.JSON;
        
        var pin = await _iisClient.GetPinCodeAsync(request.KontrAgentId, request.PinCode);
        if (string.IsNullOrEmpty(pin))
        {
            return new GetPinCodeResponse() {Success = false, ErrorMessage = "Не удалось получить пин код"};
        }

        return new GetPinCodeResponse() {Success = true, PinCode = pin};
    }
}