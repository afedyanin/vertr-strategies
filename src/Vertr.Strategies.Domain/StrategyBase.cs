using System.Collections.ObjectModel;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain;

public abstract class StrategyBase : BackgroundWorker, IStrategy
{
    public Guid Id { get; private set; }

    public Guid PortfolioId { get; private set; }

    public string Name { get; private set; }

    public ReadOnlyDictionary<string, string> Parameters { get; private set; }

    protected StrategyBase(
        Guid id,
        Guid portfolioId,
        string name,
        IDictionary<string, string> parameters)
    {
        Id = id;
        PortfolioId = portfolioId;
        Name = name;
        Parameters = new ReadOnlyDictionary<string, string>(parameters);
    }
}
