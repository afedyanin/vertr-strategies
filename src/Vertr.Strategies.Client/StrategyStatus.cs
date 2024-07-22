namespace Vertr.Strategies.Client;
public record class StrategyStatus
{
    public DateTime? StartTime { get; init; }

    public DateTime? StopTime { get; init; }

    public bool IsRunning { get; init; }

    public IEnumerable<string> Errors { get; init; } = [];

    public IEnumerable<TradeSignal> Signals { get; init; } = [];
}
