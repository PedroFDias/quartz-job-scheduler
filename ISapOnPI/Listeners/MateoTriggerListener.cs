using Quartz;

namespace SAPIntegration.Listeners
{
    public class MateoTriggerListener: ITriggerListener
    {

        public ValueTask TriggerFired (ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Trigger {trigger.Key} disparou às {DateTime.Now}");
            return ValueTask.CompletedTask;
        }
    }
}
