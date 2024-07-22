namespace Vertr.Strategies.Domain.Abstractions;
public interface IActiveStrategiesRepository
{
    void TryAdd(StrategyBase strategy);

    void TryRemove(Guid strategyId);

    IEnumerable<StrategyBase> GetAll();
}
