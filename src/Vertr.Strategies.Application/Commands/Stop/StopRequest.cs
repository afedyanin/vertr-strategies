using MediatR;

namespace Vertr.Strategies.Application.Commands.Stop;
public record class StopRequest(Guid StrategyId) : IRequest<StopResponse>
{
}
