using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Commands.Start;
public record class StartResponse(IStrategy? Strategy);
