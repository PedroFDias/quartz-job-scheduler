using Quartz;
using SAPIntegration.DTO;
using SAPIntegration.Entities;

namespace SAPIntegration.Services.Job
{
    public class SchedulerJobService
    {
        public IScheduler _scheduler;
        public SchedulerJobService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task ScheduleAsync(
            JobConfiguration jobConfiguration, 
            CancellationToken cancellationToken)
        {
            var identityKey = new JobKey (jobConfiguration.JobName);
            var triggerKey = new TriggerKey(jobConfiguration.JobName + "-trigger");

            var type = JobRegistry.GetType(jobConfiguration.JobName);

            var job = JobBuilder.Create()
                .OfType(type)
                .WithIdentity(identityKey)
                .UsingJobData(
                    "JobData",
                    jobConfiguration.JobData ?? string.Empty)
                .Build();

            var trigger = TriggerBuilder.Create()
                .ForJob(job)
                .WithIdentity(triggerKey)
                .StartNow()
                .WithCronSchedule(jobConfiguration.CronExpression)
                .Build();

            await _scheduler.ScheduleJob(job, trigger, cancellationToken: cancellationToken);
        }
    }
}