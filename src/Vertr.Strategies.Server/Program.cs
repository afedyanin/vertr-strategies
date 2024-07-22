
using Vertr.Infrastructure.Kafka;
using Vertr.Strategies.Domain.Abstractions;
using Vertr.Strategies.Domain.Services;
using Vertr.Strategies.Server.BackgroundServices;

namespace Vertr.Strategies.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<ITradeSignalsQueue, TradeSignalsInMemoryQueue>();
        builder.Services.AddHostedService<TradeSignalsPublisher>();

        builder.Services.AddOptions<KafkaSettings>().BindConfiguration("KafkaSettings");
        builder.Services.AddKafkaSettings(settings => builder.Configuration.Bind("KafkaSettings", settings));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
