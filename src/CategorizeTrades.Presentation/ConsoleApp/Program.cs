using CategorizeTrades.Application.Interfaces;
using CategorizeTrades.Application.Services;
using CategorizeTrades.Domain.Interfaces;
using CategorizeTrades.Infrastructure.Data;

namespace CategorizeTrades
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // arquivo de dados
            IPortfolio portfolio = await FileReader.LoadAsync("SampleInput/XYZBankTrading.txt");

            var categories = new List<ICategory>
        {
            new ExpiredCategory(),
            new HighRiskCategory(),
            new MediumRiskCategory()
        };

            var categorizer = new TradeCategorizer(categories);
            foreach (var trade in portfolio.Trades)
            {
                Console.WriteLine(categorizer.Categorize(trade, portfolio.ReferenceDate));
            }
        }
    }
}
