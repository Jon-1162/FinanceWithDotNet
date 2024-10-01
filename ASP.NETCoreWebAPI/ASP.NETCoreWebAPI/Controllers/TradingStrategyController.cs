using Microsoft.AspNetCore.Mvc;
//using TradingStrategySimulator.Models;
//using FinanceWithDotNet.Models;
//using ASP.NETCoreWebAPI.Models;
using CoreWebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class TradingStrategyController : ControllerBase
{
    private readonly ITradingStrategyService _tradingStrategyService;

    public TradingStrategyController(ITradingStrategyService tradingStrategyService)
    {
        _tradingStrategyService = tradingStrategyService;
    }

    [HttpGet]
    public ActionResult<TradingStrategy> Get([FromQuery] TradingStrategyRequest request)
    {
        var strategy = _tradingStrategyService.GetStrategy(request);
        if (strategy == null)
        {
            return NotFound();
        }
        return strategy;
    }
}