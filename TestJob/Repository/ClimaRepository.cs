using GenericRepository;
using TestJob.Entities;
using TestJob.Entities.Context;

namespace TestJob.Repository
{
    public class ClimaRepository : Repository<Clima, SQLServerContext>, IClimaRepository
    {
        public ClimaRepository(SQLServerContext context) : base(context) { }
    }
}
