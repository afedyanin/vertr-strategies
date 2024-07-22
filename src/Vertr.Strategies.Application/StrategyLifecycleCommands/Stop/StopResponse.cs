using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Stop;
public record class StopResponse(IStrategy? Strategy)
{
}
