using TestJob.Entities;

namespace TestJob.Services
{
    public interface IJobService
    {
        public Task<IEnumerable<JobConfiguration>> GetJobs();
    }
}
