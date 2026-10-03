using SAPIntegration.Entities;

namespace SAPIntegration.Services.Job
{
    public interface IJobService
    {
        public Task<IEnumerable<JobConfiguration>> GetJobs();
    }
}
