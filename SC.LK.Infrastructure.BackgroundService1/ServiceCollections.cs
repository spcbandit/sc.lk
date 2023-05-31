using Microsoft.Extensions.DependencyInjection;

namespace SC.LK.Infrastructure.BackgroundService;

public static class ServiceCollections
{
    public static void AddInfrastructureBackgroundService(this IServiceCollection service)
    {
        service.AddTransient<BackgroundServiceFactory>();
        service.AddScoped<DataJob>();
        
        // добавить джобы
    }
}