using Microsoft.Extensions.Logging;
using Vertr.Strategies.Domain.Abstractions;
using Vertr.Strategies.Domain.Algo;

namespace Vertr.Strategies.Domain;

public class StrategyFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StrategyFactory> _logger;

    public StrategyFactory(
        IServiceProvider serviceProvider,
        ILogger<StrategyFactory> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public IStrategy? Create(
        Guid id,
        Guid portfolioId,
        string strategyType,
        string strategyName,
        IDictionary<string, string> parameters)
    {

        if (strategyType.Equals(nameof(RandomWalkTimedStrategy), StringComparison.InvariantCultureIgnoreCase))
        {
            return new RandomWalkTimedStrategy(
                id,
                portfolioId,
                strategyName,
                parameters,
                _serviceProvider);
        }

        return null;
    }

    public static bool CanCreate(string strategyType)
    {
        if (strategyType.Equals(nameof(RandomWalkTimedStrategy), StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        return false;
    }
}
