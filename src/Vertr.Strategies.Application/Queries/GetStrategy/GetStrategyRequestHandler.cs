using MediatR;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Application.Queries.GetStrategy;

internal sealed class GetStrategyRequestHandler : IRequestHandler<GetStrategyRequest, GetStrategyResponse>
{
    private readonly IStrategiesRepository _strategiesRepository;

    public GetStrategyRequestHandler(IStrategiesRepository strategiesRepository)
    {
        _strategiesRepository = strategiesRepository;
    }

    public Task<GetStrategyResponse> Handle(GetStrategyRequest request, CancellationToken cancellationToken)
    {
        if (request.strategyId.HasValue)
        {
            var singleResponse = GetSingle(request.strategyId.Value);
            return Task.FromResult(singleResponse);
        }

        var allResponse = new GetStrategyResponse(_strategiesRepository.GetAll());

        return Task.FromResult(allResponse);
    }

    private GetStrategyResponse GetSingle(Guid strategyId)
    {
        var found = _strategiesRepository.GetById(strategyId);

        if (found != null)
        {
            return new GetStrategyResponse([found]);
        }

        return new GetStrategyResponse([]);
    }
}
