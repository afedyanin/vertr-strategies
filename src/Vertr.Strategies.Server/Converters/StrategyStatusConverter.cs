using Vertr.Strategies.Client;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Server.Converters;

internal static class StrategyStatusConverter
{
    public static StrategyStatus Convert(this IExecutionStatus executionStatus)
        => new StrategyStatus
        {
            StartTime = executionStatus.StartTime,
            StopTime = executionStatus.StopTime,
            IsRunning = executionStatus.IsRunning,
            Errors = executionStatus.Errors,
            Signals = executionStatus.Signals,
        };
}
