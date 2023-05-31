﻿using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace SC.LK.Infrastructure.BackgroundService;

public class DataScheduler
{
    public static async void Start(IServiceProvider serviceProvider)
    {
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        scheduler.JobFactory = serviceProvider.GetService<BackgroundServiceFactory>();
        await scheduler.Start();

        IJobDetail jobDetail = JobBuilder.Create<DataJob>().Build();
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("MailingTrigger", "default")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(1)
                .RepeatForever())
            .Build();

        await scheduler.ScheduleJob(jobDetail, trigger);
    }
}