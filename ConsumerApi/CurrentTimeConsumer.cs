using Contracts;
using MassTransit;

namespace ConsumerApi
{
    public class CurrentTimeConsumer(ILogger<CurrentTimeConsumer> logger): IConsumer<CurrentTime>
    {
        public Task Consume(ConsumeContext<CurrentTime> context)
        {
            logger.LogInformation("Consumer: {Consumer} - Received message: {Value}", nameof(CurrentTimeConsumer), context.Message.Value);
            return Task.CompletedTask;
        }
    }
}
