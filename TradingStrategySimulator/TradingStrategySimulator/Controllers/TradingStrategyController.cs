using Microsoft.AspNetCore.Mvc;
using TradingStrategySimulator.Models;
//using TradingStrategySimulator.Services;

[ApiController]
[Route("api/[controller]")]
public class TradingStrategyController : ControllerBase
{
    private readonly ITradingStrategyService _tradingStrategyService;

    public TradingStrategyController(ITradingStrategyService tradingStrategyService)
    {
        _tradingStrategyService = tradingStrategyService;
    }

    [HttpPost]
    public ActionResult<TradingStrategy> Post([FromBody] TradingStrategyRequest request)
    {
        var strategy = _tradingStrategyService.GetStrategy(request);
        if (strategy == null)
        {
            return NotFound();
        }
        return strategy;
    }
}