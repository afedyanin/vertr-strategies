
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vertr.Strategies.Client;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain.Algo;
public class RandomWalkTimedStrategy : StrategyBase
{
    private readonly ILogger<RandomWalkTimedStrategy> _logger;
    private readonly ITradeSignalsQueue _signalsQueue;

    private static readonly Random _random = new Random();

    // TODO: Get it from params
    private static readonly int _qtyLots = 1;
    private static readonly string _classCode = "TQBR";
    private static readonly string _symbol = "SBER";
    private static readonly int _delayMs = 1_000;

    public RandomWalkTimedStrategy(
        Guid id,
        Guid portfolioId,
        string name,
        IDictionary<string, string> parameters,
        IServiceProvider serviceProvider) : base(id, portfolioId, name, parameters, serviceProvider)
    {
        _logger = ServiceProvider.GetRequiredService<ILogger<RandomWalkTimedStrategy>>();
        _signalsQueue = ServiceProvider.GetRequiredService<ITradeSignalsQueue>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var signal = CreateSignal();

                ExecutionStatus.AddSignal(signal);
                _signalsQueue.Put(signal);

                await Task.Delay(_delayMs, stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation($"{nameof(RandomWalkTimedStrategy)} cancelled at: {DateTime.Now:T}");
        }

        _logger.LogInformation($"{nameof(RandomWalkTimedStrategy)} execution completed.");
    }

    private TradeSignal CreateSignal()
    {
        var sign = _random.Next(0, 2) == 0 ? -1 : 1;
        var qty = _qtyLots * sign;

        // market price
        return new TradeSignal(Guid.NewGuid(), Id, PortfolioId, _classCode, _symbol, qty, 0, DateTime.UtcNow);
    }
}
