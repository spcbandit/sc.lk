using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class SendCodeRequest : IRequest<SendCodeResponse>
{
    public string Login { get; set; }
}