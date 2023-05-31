using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Infrastructure.Api.Attributes;


    public class BasicAuthHandler : AuthenticationHandler<BasicAuthOptions>
    {
        private readonly IISClient _isClient;
        private readonly IRepository<UserEntity> _repositoryUser;

        public BasicAuthHandler(IRepository<UserEntity> repositoryUser, IISClient isClient,
            IOptionsMonitor<BasicAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
            _isClient = isClient ?? throw new ArgumentException(nameof(isClient));
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                string authHandler = Request.Headers["SC_Authorization"];
                if (authHandler == null)
                {
                    return AuthenticateResult.Fail("Not found Authorization header");
                }

                var authHeaderValue = AuthenticationHeaderValue.Parse(authHandler);
                if (!authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(),
                        StringComparison.OrdinalIgnoreCase))
                {
                    return AuthenticateResult.Fail("Wrong Authentication scheme");
                }

                var credentials = Encoding.UTF8
                    .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty));
                //var credentials = authHeaderValue.Parameter;

                if (credentials.Equals(null) || credentials.Equals(string.Empty) )
                {
                    return AuthenticateResult.Fail("Incorrect credentials");
                }

                var result = await IsAuthorized(credentials);
                if (result == Guid.Empty)
                {
                    return AuthenticateResult.Fail("Unrecognized client");
                }

                var claims = new[] {new Claim(ClaimTypes.Name, result.ToString())};
                var identity = new ClaimsIdentity(claims);
                var principal = new ClaimsPrincipal(identity);

                Context.User = principal;
                return AuthenticateResult.Success(new AuthenticationTicket(principal, "BasicScheme"));
            }
            catch(Exception exception)
            {
                return AuthenticateResult.Fail(exception);
            }
        }

        private async Task<Guid> IsAuthorized(string token)
        {
            try
            {
                var user = _repositoryUser.Get(x => x.Token == token).FirstOrDefault();
                if (user is null)
                {
                    return Guid.Empty;
                }
                _isClient.AuthHeader = token;
                await _isClient.GetresultAsync();
                return user.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }