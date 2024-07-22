using MediatR;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Stop;
public record class StopRequest(Guid StrategyId) : IRequest<StopResponse>
{
}
