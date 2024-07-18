namespace ASP.NETCoreWebAPI.Services
{
using MongoDB.Driver;
using System.Diagnostics;

public class TradingService
{
    private readonly IMongoCollection<TradingResult> _tradingResults;
    private readonly string _pythonScriptPath;

    public TradingService(IConfiguration config)
    {
        var client = new MongoClient(config.GetValue<string>("MongoSettings:ConnectionString"));
        var database = client.GetDatabase(config.GetValue<string>("MongoSettings:DatabaseName"));
        _tradingResults = database.GetCollection<TradingResult>("TradingResults");
        _pythonScriptPath = config.GetValue<string>("PythonSettings:ScriptPath");
    }

    public async Task<TradingResult> GetTradingResultAsync(TradingResult input)
    {
        // Generate a unique filename for the graph
        string graphFilename = $"graph_{Guid.NewGuid()}.png";
        string graphPath = Path.Combine("wwwroot", "graphs", graphFilename);

        // Call Python script to generate the graph
        await GenerateGraphAsync(input, graphPath);

        var result = new TradingResult
        {
            Id = Guid.NewGuid().ToString(),
            StockSymbol = input.StockSymbol,
            TradingStrategy = input.TradingStrategy,
            StartDate = input.StartDate,
            EndDate = input.EndDate,
            InitialInvestment = input.InitialInvestment,
            FinalValue = input.InitialInvestment * 1.1m, // Placeholder: 10% return
            GraphImagePath = $"/graphs/{graphFilename}",
            ExperimentDate = DateTime.UtcNow
        };

        await _tradingResults.InsertOneAsync(result);
        return result;
    }

    private async Task GenerateGraphAsync(TradingResult input, string outputPath)
    {
        using (var process = new Process())
        {
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = $"{_pythonScriptPath} " +
                $"{input.StockSymbol} {input.TradingStrategy} " +
                $"{input.StartDate:yyyy-MM-dd} {input.EndDate:yyyy-MM-dd} " +
                $"{input.InitialInvestment} {outputPath}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                throw new Exception($"Python script failed: {await process.StandardError.ReadToEndAsync()}");
            }
        }
    }

    public async Task<List<TradingResult>> GetAllExperimentsAsync()
    {
        return await _tradingResults.Find(_ => true).ToListAsync();
    }
}
}
