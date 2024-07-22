namespace Vertr.Strategies.Domain.Abstractions;
public interface IExecutionStatus
{
    DateTime? StartTime { get; }

    DateTime? StopTime { get; }

    bool IsRunning { get; }

    IEnumerable<string> Errors { get; }

    IEnumerable<TradeSignal> Signals { get; }
}
