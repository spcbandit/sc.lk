using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SC.LK.Application.Abstractions.Logging;
using SC.LK.Infrastructure.Logger.Middleware;

namespace SC.LK.Infrastructure.Logger;

public static class ServiceCollection
{
    /// <summary>
    /// Logger
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddInfrastructureLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LoggerOption>(configuration.GetSection("LoggerOption"));
        services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });
        services.AddSingleton<ILoggerContext, LoggerContext>();
    }
    
    /// <summary>
    /// Middleware
    /// </summary>
    /// <param name="app"></param>
    public static void UseInfrastructureLoggerMiddleware(this IApplicationBuilder app)  
    {  
        app.UseMiddleware<ExceptionHandlerMw>();  
    }  
}