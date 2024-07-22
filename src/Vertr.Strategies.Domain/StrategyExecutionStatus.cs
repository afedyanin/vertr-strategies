using Vertr.Strategies.Client;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain;

public class StrategyExecutionStatus : IExecutionStatus
{
    private readonly List<string> _errors = [];

    private readonly List<TradeSignal> _signals = [];

    public DateTime? StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    public bool IsRunning => StartTime.HasValue && !StopTime.HasValue;

    public IEnumerable<string> Errors => _errors;

    public IEnumerable<TradeSignal> Signals => _signals;

    public void AddError(string message)
        => _errors.Add(message);

    public void AddSignal(TradeSignal signal)
        => _signals.Add(signal);
}
