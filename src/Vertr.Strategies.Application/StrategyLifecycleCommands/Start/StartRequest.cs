using MediatR;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Start;
public record class StartRequest(
    Guid PortfolioId,
    string StrategyType,
    string StrategyName,
    IDictionary<string, string> parameters) : IRequest<StartResponse>
{
}
