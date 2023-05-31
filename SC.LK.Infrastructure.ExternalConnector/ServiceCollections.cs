using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions.ExternalConnectors;
using SC.LK.Application.Domains.ExternalConnectors;
using SC.LK.Infrastructure.ExternalConnector.Adaptors;

namespace SC.LK.Infrastructure.ExternalConnector;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// ExternalConnectors
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddInfrastructureExternalConnectors(this IServiceCollection services, IConfiguration configuration)
    {
        /*services.Configure<OrganizationServiceOptions>(configuration.GetSection("OrganizationServiceOptions"));
        services.AddTransient<IOrganizationInfoService, OrganizationInfoService>();*/

        services.Configure<OrganizationServiceOptions>(configuration.GetSection("FNSClientOptions"));
        services.AddTransient<IOrganizationInfoService, OrganizationInfoService>();
    }
}