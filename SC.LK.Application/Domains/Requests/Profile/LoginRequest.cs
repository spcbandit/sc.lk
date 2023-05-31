using MediatR;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Responses.Partner;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
