using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace TestJob.Entities.Context
{
    public class SQLServerContext : DbContext, IUnitOfWork
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
        public DbSet<Clima> Clima { get; set; }
        public DbSet<JobConfiguration> JobConfiguration { get; set; }
    }
}
