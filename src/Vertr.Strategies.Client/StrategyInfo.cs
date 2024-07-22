namespace Vertr.Strategies.Client;
public record class StrategyInfo(Guid Id, Guid PortfolioId, string Name, string Type, IDictionary<string, string> Parameters);
