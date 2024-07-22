using Microsoft.Extensions.DependencyInjection;
using Vertr.Strategies.Application.Queries.GetStrategy;

namespace Vertr.Strategies.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppMediator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetStrategyRequestHandler).Assembly);
        });

        return serviceCollection;
    }

}
