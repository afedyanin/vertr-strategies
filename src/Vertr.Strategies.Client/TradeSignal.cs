namespace Vertr.Strategies.Client;
public record class TradeSignal(
    Guid Id,
    Guid StrategyId,
    Guid PortfolioId,
    string ClassCode,
    string Ticker,
    decimal Price,
    decimal Qty,
    DateTime Created);
