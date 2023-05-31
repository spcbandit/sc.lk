using Microsoft.Extensions.DependencyInjection;
using SC.LK.Infrastructure.BackgroundService.Adaptors;

namespace SC.LK.Infrastructure.BackgroundService;

public static class ServiceCollection
{
    public static void AddInfrastructureBackgroundService(this IServiceCollection service)
    {
        service.AddHostedService<TimedHostedService>();
    }
}