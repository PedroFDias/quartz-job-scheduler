using Quartz;
using TestJob.Repository;
using TestJob.Services;

namespace TestJob.Workers
{
    public class GetJobsWorker : BackgroundService
    {
        public IConfiguration _configuration;
        public IServiceScopeFactory _serviceScopeFactory;
        public IScheduler _scheduler;

        public GetJobsWorker(
            IConfiguration configuration, 
            IServiceScopeFactory serviceScopeFactory,
            IScheduler scheduler)
        {
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            _scheduler = scheduler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceScopeFactory.CreateScope();

            var jobService = scope.ServiceProvider.GetRequiredService<IJobService>();
            var quartzScheduler = scope.ServiceProvider.GetRequiredService<SchedulerJobService>();

            var jobs = await jobService.GetJobs();

            foreach (var job in jobs)
            {
                await quartzScheduler.ScheduleAsync(job, stoppingToken);
            }
        }
    }
}
