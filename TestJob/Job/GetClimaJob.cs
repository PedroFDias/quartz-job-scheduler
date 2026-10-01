using AutoMapper;
using Quartz;
using TestJob.DTO;
using TestJob.Entities;
using TestJob.Services;

namespace TestJob.Job
{
    public class GetClimaJob : IJob
    {
        private readonly HttpClient _httpClient;
        private readonly IClimaService _climaService;
        private readonly IConfiguration _configuration;

        public GetClimaJob(
            HttpClient httpClient,
            IClimaService climaService,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _climaService = climaService;
            _configuration = configuration;
        }

        public async ValueTask Execute(
            IJobExecutionContext context,
            CancellationToken cancellationToken = default)
        {
            var data = context.MergedJobDataMap;
            var url = data.GetString("Climaurl");

            if (string.IsNullOrWhiteSpace(url))
            {
                url = data.GetString("JobData");
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                url = _configuration.GetConnectionString("UrlMateoClima");
            }

            Console.WriteLine($"url: {url}");

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new InvalidOperationException(
                    "URL do clima não encontrada. Preencha JobData ou ConnectionStrings:UrlMateoClima.");
            }

            var resposta = await _httpClient.GetFromJsonAsync<RespostaClimaDTO>(
                url,
                cancellationToken);

            Console.WriteLine($"resposta: {resposta}");

            await _climaService.AddAsync(resposta.Clima);
        }
    }
}
