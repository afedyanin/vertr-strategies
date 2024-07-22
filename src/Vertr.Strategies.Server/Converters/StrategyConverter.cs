using Vertr.Strategies.Client;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Server.Converters;

internal static class StrategyConverter
{
    public static IEnumerable<StrategyInfo> Convert(this IEnumerable<IStrategy> strategies)
        => strategies.Select(Convert);

    public static StrategyInfo Convert(this IStrategy strategy)
        => new StrategyInfo(
            strategy.Id,
            strategy.PortfolioId,
            strategy.Name,
            strategy.GetType().Name,
            strategy.Parameters);
}
