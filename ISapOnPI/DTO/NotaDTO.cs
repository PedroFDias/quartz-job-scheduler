using Patrify.MessageBus.Contracts.Enum;
using SAPIntegration.Entities;

namespace SAPIntegration.DTO
{
    public class NotaDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateName { get; set; }
        public DateTime StartTime { get; set; }
        public string Severity { get; set; }
        public bool CanBeAcknowledged { get; set; }
        public StatusNota Status { get; set; } = StatusNota.Pending;

        public static explicit operator Nota(NotaDTO notaDTO)
        {
            return new Nota
            {
                Name = notaDTO.Name,
                Description = notaDTO.Description,
                TemplateName = notaDTO.TemplateName,
                StartTime = notaDTO.StartTime,
                Severity = notaDTO.Severity,
                CanBeAcknowledged = notaDTO.CanBeAcknowledged
            };
        }
    }
}
