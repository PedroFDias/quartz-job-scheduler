using GenericRepository;
using SAPIntegration.DTO;
using SAPIntegration.Repositories.Nota;

namespace SAPIntegration.Services.Nota
{
    public class NotaService : INotaService
    {
        public IUnitOfWork _unitOfWork;
        public INotaRepository _repository{ get; set; }
        public NotaService(IUnitOfWork unitOfWork, INotaRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public Task AddNota(NotaDTO notaDTO)
        {
            var nota2 = (Entities.Nota)notaDTO;
            _repository.Add(nota2);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}
