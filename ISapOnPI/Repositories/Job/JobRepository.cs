using GenericRepository;
using SAPIntegration.Entities;
using SAPIntegration.Entities.Context;

namespace SAPIntegration.Repositories.Job
{
    public class JobRepository: Repository<JobConfiguration, SQLServerContext>, IJobRepository
    {
        public JobRepository(SQLServerContext context) : base(context) { }
    }
}
