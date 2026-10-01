using System.Text.Json.Serialization;
using TestJob.Entities;

namespace TestJob.DTO
{
    public class ClimaDTO
    {
        [JsonPropertyName("time")]
        public DateTime Hora { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperatura { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int UmidadeRelativa { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public double SensacaoTermica { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitacao { get; set; }

        [JsonPropertyName("weather_code")]
        public int CodigoClima { get; set; }

        [JsonPropertyName("cloud_cover")]
        public int CoberturaNuvens { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double VelocidadeVento { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public int DirecaoVento { get; set; }

        public static implicit operator Clima(ClimaDTO dto)
        {
            return new Clima
            {
                Hora = dto.Hora,
                Temperatura = dto.Temperatura,
                UmidadeRelativa = dto.UmidadeRelativa,
                SensacaoTermica = dto.SensacaoTermica,
                Precipitacao = dto.Precipitacao,
                CodigoClima = dto.CodigoClima,
                CoberturaNuvens = dto.CoberturaNuvens,
                VelocidadeVento = dto.VelocidadeVento,
                DirecaoVento = dto.DirecaoVento
            };
        }
    }
}
