using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.IdentityService.Requests;

public class LoginRequest : IRequest<LoginResponse>
{
    /// <summary>
    /// Login
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// ServiceId
    /// </summary>
    public IEnumerable<Services> ServiceId { get; set; } = null!;
}