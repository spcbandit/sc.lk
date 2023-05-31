using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class PasswordResetRequest : IRequest<PasswordResetResponse>
{
    public string Login { get; set; }
    public string Password { get; set; }
    
    public string? AuthCode { get; set; }
}