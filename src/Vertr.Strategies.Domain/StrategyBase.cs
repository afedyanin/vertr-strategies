using System.Collections.ObjectModel;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain;

public abstract class StrategyBase : BackgroundWorker, IStrategy
{
    public Guid Id { get; private set; }

    public Guid PortfolioId { get; private set; }

    public string Name { get; private set; }

    public ReadOnlyDictionary<string, string> Parameters { get; private set; }

    public IExecutionStatus Status => ExecutionStatus;

    protected virtual StrategyExecutionStatus ExecutionStatus { get; private set; }

    protected IServiceProvider ServiceProvider { get; private set; }

    protected StrategyBase(
        Guid id,
        Guid portfolioId,
        string name,
        IDictionary<string, string> parameters,
        IServiceProvider serviceProvider)
    {
        Id = id;
        PortfolioId = portfolioId;
        Name = name;
        Parameters = new ReadOnlyDictionary<string, string>(parameters);
        ServiceProvider = serviceProvider;
        ExecutionStatus = new StrategyExecutionStatus();
    }

    public override Task StartAsync(CancellationToken cancellationToken = default)
    {
        ExecutionStatus.StartTime = DateTime.UtcNow;
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken = default)
    {
        ExecutionStatus.StopTime = DateTime.UtcNow;
        return base.StopAsync(cancellationToken);
    }
}
