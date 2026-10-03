using Patrify.MessageBus.RabbitMQ.Publish;
using Quartz;
using SAPIntegration.DTO;
using SAPIntegration.Services.Nota;

namespace SAPIntegration.Job
{
    public class GetNotasSap : IJob
    {
        public IServiceScopeFactory _serviceScopeFactory;
        public IRabbitMQPublish _rabbitMQPublish;
        public GetNotasSap(IRabbitMQPublish rabbitMQPublish, IServiceScopeFactory serviceScopeFactory)
        {
            _rabbitMQPublish = rabbitMQPublish;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INotaService>();


            Console.WriteLine("Salvando nova nota!");
            var notaDTO = new NotaDTO
            {
                Name = "Nota SAP",
                Description = "Esta es una nota de SAP",
                TemplateName = "SAPTemplate",
                StartTime = DateTime.Now,
                Severity = "High",
                CanBeAcknowledged = true
            };

            await service.AddNota(notaDTO);

            await _rabbitMQPublish.Publish(
                notaDTO,
                "sap-pi.Exchange",
                "topic",
                "nota.created"
            );
        }
    }
}
