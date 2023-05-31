using System.Runtime.Serialization;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher;

public static class ServiceCollection
{
    /// <summary>
    /// AddInfrastructureConfiguratorDispatcher
    /// </summary>
    /// <param name="services"></param>
    public static void AddInfrastructureConfiguratorDispatcher(this IServiceCollection services)
    {
        services.AddTransient<IHtmlGenerator, ConfigurationHtmlGenerator>();
    }
}