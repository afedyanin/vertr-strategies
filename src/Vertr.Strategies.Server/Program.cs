
using Vertr.Infrastructure.Kafka;
using Vertr.Strategies.Domain;
using Vertr.Strategies.Domain.Abstractions;
using Vertr.Strategies.Domain.Services;
using Vertr.Strategies.Server.BackgroundServices;
using Vertr.Strategies.Application;
using Vertr.Strategies.Domain.Repositories;

namespace Vertr.Strategies.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOptions<KafkaSettings>().BindConfiguration("KafkaSettings");
        builder.Services.AddKafkaSettings(settings => builder.Configuration.Bind("KafkaSettings", settings));

        builder.Services.AddHostedService<TradeSignalsPublisher>();
        builder.Services.AddSingleton<ITradeSignalsQueue, TradeSignalsInMemoryQueue>();
        builder.Services.AddSingleton<IStrategiesRepository, StrategiesInMemoryRepository>();

        builder.Services.AddSingleton<StrategyFactory>();
        builder.Services.AddAppMediator();

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
