using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SAPIntegration.Entities.Context
{
    public class SQLServerContext : DbContext, IUnitOfWork
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
        public DbSet<JobConfiguration> JobConfiguration { get; set; }
        public DbSet<Nota> Nota { get; set; }
    }
}
