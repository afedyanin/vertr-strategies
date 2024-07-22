using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Queries.GetStrategy;
public record GetStrategyResponse(IEnumerable<IStrategy> Strategies);
