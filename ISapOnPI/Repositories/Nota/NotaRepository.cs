using GenericRepository;
using SAPIntegration.Entities.Context;

namespace SAPIntegration.Repositories.Nota
{
    public class NotaRepository : Repository<Entities.Nota, SQLServerContext>, INotaRepository
    {
        public NotaRepository(SQLServerContext context) : base(context)
        {
        }
    }
}
