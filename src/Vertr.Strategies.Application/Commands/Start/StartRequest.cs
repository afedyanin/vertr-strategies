using MediatR;

namespace Vertr.Strategies.Application.Commands.Start;
public record class StartRequest(
    Guid PortfolioId,
    string StrategyType,
    string StrategyName,
    IDictionary<string, string> Parameters) : IRequest<StartResponse>
{
}
