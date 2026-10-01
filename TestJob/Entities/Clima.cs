using System.ComponentModel.DataAnnotations;

namespace TestJob.Entities
{
    public class Clima
    {
        [Key]
        public Guid Id { get; set;  } = Guid.NewGuid();
        public DateTime Hora { get; set; }
        public double Temperatura { get; set; }
        public int UmidadeRelativa { get; set; }
        public double SensacaoTermica { get; set; }
        public double Precipitacao { get; set; }
        public int CodigoClima { get; set; }
        public int CoberturaNuvens { get; set; }
        public double VelocidadeVento { get; set; }
        public int DirecaoVento { get; set; }
    }
}
