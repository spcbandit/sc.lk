using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace SC.LK.Infrastructure.BackgroundService;

public class BackgroundServiceFactory: IJobFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    
    public BackgroundServiceFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var job = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            return job;
        }
    }

    public void ReturnJob(IJob job)
    {
        throw new NotImplementedException();
    }
}