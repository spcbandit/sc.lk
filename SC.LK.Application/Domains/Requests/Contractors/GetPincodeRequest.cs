using MediatR;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Domains.Requests.Contractors;

public class GetPincodeRequest : IRequest<GetPinCodeResponse>
{
    public Guid KontrAgentId { get; set; }
    public int PinCode { get; set; }
}