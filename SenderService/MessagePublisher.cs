using Contracts;
using MassTransit;

namespace SenderService
{
    public class MessagePublisher(IBus bus) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = new CurrentTime { Value = $"The current time is: {DateTime.UtcNow}" };
                await bus.Publish(message, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
