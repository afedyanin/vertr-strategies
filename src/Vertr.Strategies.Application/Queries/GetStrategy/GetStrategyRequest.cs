using MediatR;

namespace Vertr.Strategies.Application.Queries.GetStrategy;

public record GetStrategyRequest(Guid? strategyId) : IRequest<GetStrategyResponse>
{
}
