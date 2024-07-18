namespace ASP.NETCoreWebAPI.Services
{

    public class TradingResult
    {
        public string Id { get; set; }
        public string StockSymbol { get; set; }
        public string TradingStrategy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal FinalValue { get; set; }
        public string GraphImagePath { get; set; }
        public DateTime ExperimentDate { get; set; }

    }
}