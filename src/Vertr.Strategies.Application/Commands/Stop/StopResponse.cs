using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Commands.Stop;
public record class StopResponse(IStrategy? Strategy)
{
}
