using System.Collections.ObjectModel;

namespace Vertr.Strategies.Domain.Abstractions;

public interface IStrategy
{
    Guid Id { get; }

    Guid PortfolioId { get; }

    string Name { get; }

    ReadOnlyDictionary<string, string> Parameters { get; }

    Task StartAsync(CancellationToken cancellationToken = default);

    Task StopAsync(CancellationToken cancellationToken = default);
}
