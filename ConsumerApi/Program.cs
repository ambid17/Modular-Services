using MassTransit;

namespace ConsumerApi
{
    // // based on : https://www.youtube.com/watch?v=MzC0PgYocmk
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddMassTransit(busConfig =>
            {
                busConfig.SetKebabCaseEndpointNameFormatter();
                
                busConfig.UsingRabbitMq((context, cfg) =>
                {
                    // Host: where the docker image is running
                    // virtual host: RabbitMQ's enforces logical separation of resources per virtual host
                    // Username and password: default credentials for RabbitMQ
                    // this infers the default ports for rabbitmq
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ConfigureEndpoints(context);
                });

                // Register ALL consumers from the current assembly
                busConfig.AddConsumers(typeof(Program).Assembly);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
