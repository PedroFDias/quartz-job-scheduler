using GenericRepository;
using TestJob.Entities;
using TestJob.Entities.Context;

namespace TestJob.Repository
{
    public class JobRepository: Repository<JobConfiguration, SQLServerContext>, IJobRepository
    {
        public JobRepository(SQLServerContext context) : base(context) { }
    }
}
