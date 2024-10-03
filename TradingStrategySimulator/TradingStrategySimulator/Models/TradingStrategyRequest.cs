namespace TradingStrategySimulator.Models;
public class TradingStrategyRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? StartDate { get; set; }
    public decimal? initialInvestment { get; set; }
}