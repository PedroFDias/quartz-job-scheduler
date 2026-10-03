using GenericRepository;
using Quartz;
using System.Collections;
using SAPIntegration.Entities;
using SAPIntegration.Repositories.Job;

namespace SAPIntegration.Services.Job
{
    public class JobService: IJobService
    {
        public IJobRepository _jobRepository;
        public IUnitOfWork _unitOfWork;
        public IScheduler _scheduler;

        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JobConfiguration>> GetJobs()
        {
            var jobs = _jobRepository.Where(x => x.Ativo);
            return jobs;
        }
    }
}
