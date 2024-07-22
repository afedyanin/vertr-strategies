
using Vertr.Strategies.Domain;

namespace Vertr.Strategies.Server.BackgroundServices;

public class StrategyLifecycleService : BackgroundService
{
    private readonly Dictionary<Guid, StrategyBase> _activeStrategies = new Dictionary<Guid, StrategyBase>();

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
