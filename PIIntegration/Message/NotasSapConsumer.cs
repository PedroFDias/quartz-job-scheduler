using Patrify.MessageBus.Contracts.Events;
using Patrify.MessageBus.RabbitMQ.Consumer;

namespace PIIntegration.Message
{
    public class NotasSapConsumer : BackgroundService
    {
        private IRabbitMQConsumer _rabbitMQConsumer;
        private IServiceScopeFactory _serviceScopeFactory;
        public NotasSapConsumer(IRabbitMQConsumer rabbitMQConsumer, IServiceScopeFactory serviceScopeFactory)
        {
            _rabbitMQConsumer = rabbitMQConsumer;
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMQConsumer.ConsumeAsync<CreateNotaSapEvent>(
                "sap-pi.Exchange",
                "topic",
                "sap-pi.nota.created",
                "nota.created", 
                async (createNotaSapEvent) =>
                {
                    try{
                        Console.WriteLine($"Consumindo notas: {createNotaSapEvent.Name}");
                    }catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing message: {ex.Message}");
                    }
                }
            );
        }
    }
}
