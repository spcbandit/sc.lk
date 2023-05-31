using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Infrastructure.Api.Attributes;
using SC.LK.Infrastructure.Api.AuthSchemas;

namespace SC.LK.Infrastructure.Api;

public static class ServiceCollection
{
    /// <summary>
    /// AddSchemasAuthenticate
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSchemasAuthenticate(this AuthenticationBuilder builder)
    {
        builder
            .AddScheme<BasicAuthOptions, AbsoluteSchema>("AbsoluteSchema", null);
    }

    /// <summary>
    /// AddSchemasAuthenticate
    /// </summary>
    /// <param name="services"></param>
    public static void AddSchemasAuthenticate(this IServiceCollection services)
    {

        services.AddAuthorization(x =>
            x.AddPolicy("AbsoluteSchema",
                policy =>
                {
                    policy.AddAuthenticationSchemes("AbsoluteSchema");
                    policy.RequireClaim(ClaimTypes.Name);
                }));
    }
}