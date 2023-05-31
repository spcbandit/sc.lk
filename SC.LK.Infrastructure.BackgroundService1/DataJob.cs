using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace SC.LK.Infrastructure.BackgroundService;

public class DataJob: IJob
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DataJob(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            // Регистрация джобы
            //var emailsender = scope.ServiceProvider.GetService<IEmailSender>();

            //await emailsender.SendEmailAsync("example@gmail.com", "example", "hello");
        }
    }
}