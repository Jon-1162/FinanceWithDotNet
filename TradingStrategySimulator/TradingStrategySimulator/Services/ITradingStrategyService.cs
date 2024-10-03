using TradingStrategySimulator.Models;


public interface ITradingStrategyService
{
    TradingStrategy GetStrategy(TradingStrategyRequest request);
}

public class TradingStrategyService : ITradingStrategyService
{
    public TradingStrategy GetStrategy(TradingStrategyRequest request)
    {
        int id = request.Id;
        
        return new TradingStrategy
        {
            Id = id,
            priceOverTime = new List<double> { 33.0, 22.0, 44.0, 55.0, 23.0 },
            finalValue = 7.7
        };
    }
}