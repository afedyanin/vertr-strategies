using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertr.Strategies.Application.Commands.Start;
using Vertr.Strategies.Application.Commands.Stop;
using Vertr.Strategies.Application.Queries.GetStrategy;
using Vertr.Strategies.Client;
using Vertr.Strategies.Server.Converters;

namespace Vertr.Strategies.Server.Controllers;
[Route("api/strategies")]
[ApiController]

public class StrategiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StrategiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("start")]
    public async Task<ActionResult<StrategyInfo>> Start(StrategyStartRequest start)
    {
        var req = new StartRequest(
            start.PortfolioId,
            start.StrategyType,
            start.StrategyName,
            start.Parameters);

        var response = await _mediator.Send(req);
        var strategy = response.Strategy;

        if (strategy == null)
        {
            return BadRequest();
        }

        return Ok(strategy.Convert());
    }

    [HttpPost("stop/{strategyId:guid}")]
    public async Task<ActionResult> Stop(Guid strategyId)
    {
        var req = new StopRequest(strategyId);
        var response = await _mediator.Send(req);
        var strategy = response.Strategy;

        if (strategy == null)
        {
            return NotFound();
        }

        return Ok(strategy.Status);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<StrategyInfo>>> GetAll()
    {
        var req = new GetStrategyRequest(null);
        var response = await _mediator.Send(req);
        var res = response.Strategies.Convert();
        return Ok(res);
    }

    [HttpGet("{strategyId:guid}")]
    public async Task<ActionResult<StrategyInfo>> GetStrategy(Guid strategyId)
    {
        var req = new GetStrategyRequest(strategyId);
        var response = await _mediator.Send(req);
        var res = response.Strategies.SingleOrDefault();

        if (res == null)
        {
            return NotFound();
        }

        return Ok(res.Convert());
    }

    [HttpGet("{strategyId:guid}/status")]
    public async Task<ActionResult> GetStrategyStatus(Guid strategyId)
    {
        var req = new GetStrategyRequest(strategyId);
        var response = await _mediator.Send(req);
        var res = response.Strategies.SingleOrDefault();

        if (res == null)
        {
            return NotFound();
        }

        var status = res.Status;

        return Ok(status);
    }
}
