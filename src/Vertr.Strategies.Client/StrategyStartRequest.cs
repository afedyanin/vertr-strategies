namespace Vertr.Strategies.Client;

public record class StrategyStartRequest(
    Guid PortfolioId,
    string StrategyType,
    string StrategyName,
    IDictionary<string, string> Parameters);
