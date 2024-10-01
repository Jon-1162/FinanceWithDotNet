public interface ITradingStrategyService
{
    TradingStrategy GetStrategy(int id);// (int id, string strategyName, int initialVal, string stockSymbol, DateTime startDate , DateTime endDate )
}

public class TradingStrategyService : ITradingStrategyService
{
    public TradingStrategy GetStrategy(int id) // (int id, string strategyName, int initialVal, string stockSymbol, DateTime startDate , DateTime endDate )
    {
        // In a real application, you'd fetch this from a database
        return new TradingStrategy 
        { 
            Id = id,
            priceOverTime = new List<double> { 33.0, 22.0, 44.0, 55.0, 23.0 },
            finalValue = 7.7 
        };
    }
}