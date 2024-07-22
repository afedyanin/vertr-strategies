namespace Vertr.Strategies.Domain.Abstractions;

public interface IStrategy
{
    public Guid Id { get; }

    public Guid PortfolioId { get; }

    public string Type { get; }

    public string Name { get; }

    public IDictionary<string, string> Parameters { get; }

    public Task StartAsync(CancellationToken cancellationToken = default);

    public Task StopAsync();
}
