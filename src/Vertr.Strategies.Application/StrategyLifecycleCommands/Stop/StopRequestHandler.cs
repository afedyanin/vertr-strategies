using MediatR;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Stop;
internal sealed class StopRequestHandler : IRequestHandler<StopRequest, StopResponse>
{
    public Task<StopResponse> Handle(StopRequest request, CancellationToken cancellationToken)
    {
        // 1. Find strategy
        // 2. Stop it
        // 3. Return stopped strategy?
        throw new NotImplementedException();
    }
}
