
using Microsoft.Extensions.Options;
using Vertr.Infrastructure.Kafka;
// using Vertr.Infrastructure.Kafka.Abstractions;
// using Vertr.Strategies.Client;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Server.BackgroundServices;

public class TradeSignalsPublisher : BackgroundService
{
    public static readonly string TradeSignalTopicKey = "TradeSignals";

    private readonly IServiceProvider _services;
    private readonly ILogger<TradeSignalsPublisher> _logger;
    // private readonly string _tradeSignalsTopic;

    public TradeSignalsPublisher(
        IServiceProvider services,
        IOptions<KafkaSettings> kafkaSettings,
        ILogger<TradeSignalsPublisher> logger
        )
    {
        _services = services;
        _logger = logger;

        // var topics = kafkaSettings.Value.Topics;
        // topics.TryGetValue(TradeSignalTopicKey, out var tradeSignalsTopic);
        // _tradeSignalsTopic = tradeSignalsTopic ?? throw new ArgumentException("Order trades topic is not defined.");

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Start publishing trading signals.");

        var signalsProvider = _services.GetRequiredService<ITradeSignalsQueue>();
        // var kafkaProducer = _services.GetRequiredService<IProducerWrapper<string, TradeSignal>>();

        while (stoppingToken.IsCancellationRequested)
        {
            while (signalsProvider.TryGet(out var signal))
            {
                if (signal == null)
                {
                    break;
                }
                _logger.LogDebug($"Publishing signal={signal}");
                // await kafkaProducer.Produce(_tradeSignalsTopic, signal.PortfolioId.ToString(), signal, null, stoppingToken);
            }

            await Task.Delay(10);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogWarning("Trading signals publishing is stopping.");
        await base.StopAsync(stoppingToken);
    }
}
