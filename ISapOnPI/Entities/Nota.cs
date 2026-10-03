using SAPIntegration.Entities.Enum;

namespace SAPIntegration.Entities
{
    public class Nota
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateName { get; set; }
        public DateTime StartTime { get; set; }
        public string Severity { get; set; }
        public bool CanBeAcknowledged { get; set; }
        public StatusNotaEnum Status { get; set; }
    }
}
