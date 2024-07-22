namespace Vertr.Strategies.Domain.Abstractions;
public interface IStrategiesRepository
{
    bool TryAdd(IStrategy strategy);

    bool TryRemove(Guid strategyId);

    IStrategy? GetById(Guid id);

    IEnumerable<IStrategy> GetAll();
}
