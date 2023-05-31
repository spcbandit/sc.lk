using MediatR;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile
{
    public class LogoutRequest : IRequest<LogoutResponse>
    {
    }
}
