using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradingController : ControllerBase
    {
        private readonly TradingService _tradingService;

        public TradingController(TradingService tradingService)
        {
            _tradingService = tradingService;
        }

        [HttpPost]
        public async Task<IActionResult> GetTradingResult([FromBody] TradingResult input)
        {
            var result = await _tradingService.GetTradingResultAsync(input);
            return Ok(result);
        }

        [HttpGet("experiments")]
        public async Task<IActionResult> GetAllExperiments()
        {
            var experiments = await _tradingService.GetAllExperimentsAsync();
            return Ok(experiments);
        }
    }
}
