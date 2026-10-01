using TestJob.DTO;

namespace TestJob.Services
{
    public interface IClimaService
    {
        Task AddAsync(ClimaDTO clima);
    }
}
