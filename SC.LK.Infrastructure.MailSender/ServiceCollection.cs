using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.MailSender;
using SC.LK.Infrastructure.MailSender.Adaptors;

namespace SC.LK.Infrastructure.MailSender;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// MailSender
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddInfrastructureMailSender(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailKitOptions>(configuration.GetSection("MailKitOptions"));
        services.Configure<AdminMailKitOptions>(configuration.GetSection("AdminMailKitOptions"));
        services.AddTransient<IMailKit, MailKitAdaptor>();
    }
}