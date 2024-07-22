using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain;

public abstract class StrategyBase : IStrategy, IDisposable
{
    private readonly CancellationTokenSource _tokenSource;

    public Guid Id { get; private set; }

    public Guid PortfolioId { get; private set; }

    public string Name { get; private set; }

    public IDictionary<string, string> Parameters { get; private set; }

    protected StrategyBase(
        Guid id,
        Guid portfolioId,
        string name,
        IDictionary<string, string> parameters)
    {
        Id = id;
        PortfolioId = portfolioId;
        Name = name;
        Parameters = parameters;

        _tokenSource = new CancellationTokenSource();
    }

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        var task = Task.Run(async () =>
        {
            await ExecuteAsync(cancellationToken);

        }, _tokenSource.Token);

        return task;
    }

    public Task StopAsync()
    {
        _tokenSource.Cancel();
    }

    protected virtual async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // DO WORK
            await Task.Delay(100);
        }
    }

    public void Dispose()
    {
        _tokenSource.Dispose();
    }
}
