using System.Collections.Concurrent;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain.Repositories;

public class StrategiesInMemoryRepository : IStrategiesRepository
{
    private readonly ConcurrentDictionary<Guid, IStrategy> _strategies;

    public StrategiesInMemoryRepository()
    {
        _strategies = [];
    }

    public bool TryAdd(IStrategy strategy)
    {
        return _strategies.TryAdd(strategy.Id, strategy);
    }

    public bool TryRemove(Guid strategyId)
    {
        return _strategies.TryRemove(strategyId, out var _);
    }

    public IEnumerable<IStrategy> GetAll()
    {
        return _strategies.Values;
    }

    public IStrategy? GetById(Guid id)
    {
        if (_strategies.TryGetValue(id, out var strategy))
        {
            return strategy;
        }

        return null;
    }
}
