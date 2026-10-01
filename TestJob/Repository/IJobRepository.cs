using GenericRepository;
using TestJob.Entities;

namespace TestJob.Repository
{
    public interface IJobRepository: IRepository<JobConfiguration>
    {
    }
}
