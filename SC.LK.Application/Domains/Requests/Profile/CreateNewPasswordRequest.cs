using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class CreateNewPasswordRequest : IRequest<CreateNewPasswordResponse>
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
    public string Code { get; set; }
}