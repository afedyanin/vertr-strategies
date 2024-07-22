using MediatR;
using Microsoft.Extensions.Logging;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Commands.Stop;
internal sealed class StopRequestHandler : IRequestHandler<StopRequest, StopResponse>
{
    private readonly IStrategiesRepository _strategiesRepository;
    private readonly ILogger<StopRequestHandler> _logger;

    public StopRequestHandler(
        IStrategiesRepository strategiesRepository,
        ILogger<StopRequestHandler> logger)
    {
        _strategiesRepository = strategiesRepository;
        _logger = logger;
    }

    public async Task<StopResponse> Handle(StopRequest request, CancellationToken cancellationToken)
    {
        var strategy = _strategiesRepository.GetById(request.StrategyId);

        var response = new StopResponse(strategy);

        if (strategy == null)
        {
            _logger.LogError($"Cannot find strategy Id={request.StrategyId}");
            return response;
        }

        await strategy.StopAsync(cancellationToken);

        // TODO: Should remove stopped strategy?
        return response;
    }
}
