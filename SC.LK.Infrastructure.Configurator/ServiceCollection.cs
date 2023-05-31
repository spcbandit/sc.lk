using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Infrastructure.ElementCreator.Adaptors;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher;

public static class ServiceCollection
{
    public static void AddInfrastructureConfiguratorDispatcher(this IServiceCollection services)
    {
        services.AddTransient<IElementCreator, ElementCreator.Adaptors.ElementCreator>();
        
        services.AddTransient<IConfigurationCreator, ConfigurationCreator>();
    }
}