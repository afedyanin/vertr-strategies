namespace Vertr.Strategies.Domain.Commands;
public record class StartCommand(Guid PortfolioId, string StrategyType);
