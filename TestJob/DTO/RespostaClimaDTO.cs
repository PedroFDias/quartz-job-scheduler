using System.Text.Json.Serialization;

namespace TestJob.DTO
{
    public class RespostaClimaDTO
    {
        [JsonPropertyName("current")]
        public ClimaDTO Clima { get; set; }
    }
}
