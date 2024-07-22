using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Strategies.Domain;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Commands.Start;
internal sealed class StartRequestHandler : IRequestHandler<StartRequest, StartResponse>
{
    private readonly StrategyFactory _strategyFactory;
    private readonly IStrategiesRepository _strategiesRepository;
    private readonly ILogger<StartRequestHandler> _logger;

    public StartRequestHandler(
        StrategyFactory strategyFactory,
        IStrategiesRepository strategiesRepository,
        ILogger<StartRequestHandler> logger)
    {
        _strategyFactory = strategyFactory;
        _strategiesRepository = strategiesRepository;
        _logger = logger;
    }

    public async Task<StartResponse> Handle(StartRequest request, CancellationToken cancellationToken)
    {
        var strategy = _strategyFactory.Create(
            Guid.NewGuid(),
            request.PortfolioId,
            request.StrategyType,
            request.StrategyName,
            request.Parameters);

        var response = new StartResponse(strategy);

        if (strategy == null)
        {
            _logger.LogError($"Cannot create strategy. Type={request.StrategyType}");
            return response;
        }

        // always ok: new guid as key
        _strategiesRepository.TryAdd(strategy);

        await strategy.StartAsync();

        return response;
    }
}
