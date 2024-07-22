using MediatR;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Start;
internal sealed class StartRequestHandler : IRequestHandler<StartRequest, StartResponse>
{
    public Task<StartResponse> Handle(StartRequest request, CancellationToken cancellationToken)
    {
        // 1. Create strategy from factory
        // 2. Save into active strategy repo
        // 3. Start strategy
        // 4. Return strategy
        throw new NotImplementedException();
    }
}
