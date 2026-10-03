using SAPIntegration.DTO;

namespace SAPIntegration.Services.Nota
{
    public interface INotaService
    {
        Task AddNota(NotaDTO nota);
    }
}
