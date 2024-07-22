using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.StrategyLifecycleCommands.Start;
public record class StartResponse(IStrategy? Strategy);
