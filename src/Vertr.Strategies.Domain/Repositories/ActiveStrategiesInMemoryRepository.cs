using System.Collections.Concurrent;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain.Repositories;

public class ActiveStrategiesInMemoryRepository
{
    private readonly ConcurrentDictionary<Guid, IStrategy> _activeStrategies;

    public ActiveStrategiesInMemoryRepository()
    {
        _activeStrategies = [];
    }

    public void TryAdd(IStrategy strategy)
    {
        _activeStrategies.TryAdd(strategy.Id, strategy);
    }

    public void TryRemove(Guid strategyId)
    {
        _activeStrategies.TryRemove(strategyId, out var _);
    }

    public IEnumerable<IStrategy> GetAll()
    {
        return _activeStrategies.Values;
    }
}
