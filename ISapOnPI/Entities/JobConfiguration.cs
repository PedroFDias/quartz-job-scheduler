using System.ComponentModel.DataAnnotations;

namespace SAPIntegration.Entities
{
    public class JobConfiguration
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string JobName { get; set; } = string.Empty;
        [StringLength(20)]
        public string CronExpression { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public string? JobData { get; set; }
    }
}
