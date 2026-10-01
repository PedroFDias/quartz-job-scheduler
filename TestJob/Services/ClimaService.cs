using AutoMapper;
using GenericRepository;
using TestJob.DTO;
using TestJob.Entities;
using TestJob.Repository;

namespace TestJob.Services
{
    public class ClimaService: IClimaService
    {
        private readonly IClimaRepository _climaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClimaService(IClimaRepository climaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _climaRepository = climaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ClimaDTO climaDto)
        {
            Clima clima = climaDto;
            Console.WriteLine("Precipitação: "+ clima.Precipitacao);
            Console.WriteLine("Hora: "+ clima.Hora.ToString());
            Console.WriteLine("UmidadeRelativa: "+ clima.UmidadeRelativa);
            Console.WriteLine("DirecaoVento: "+ clima.DirecaoVento);
            Console.WriteLine("CodigoClima: "+ clima.CodigoClima);
            await _climaRepository.AddAsync(clima);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
