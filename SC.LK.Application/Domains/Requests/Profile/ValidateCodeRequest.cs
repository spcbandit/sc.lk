using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class ValidateCodeRequest : IRequest<ValidateCodeResponse>
{
    public string AuthCode { get; set; }
    public string Login { get; set; }
}