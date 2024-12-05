using CategorizeTrades.Domain.Entities;
using CategorizeTrades.Domain.Interfaces;
using System.Globalization;

namespace CategorizeTrades.Infrastructure.Data
{
    public class FileReader
    {
        public static async Task<IPortfolio> LoadAsync(string caminhoArquivo)
        {
            using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new StreamReader(stream);

            DateTime referenceDate = DateTime.ParseExact(await reader.ReadLineAsync(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

            int quantityTrades = int.Parse(await reader.ReadLineAsync());

            var trades = new List<ITrade>();

            for (int i = 0; i < quantityTrades; i++)
            {
                string line = await reader.ReadLineAsync();
                if (line is null)
                    throw new InvalidDataException("File corrupt or has fewer lines than expected.");

                var elements = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length != 3)
                    throw new FormatException("Format of the trade line is incorrect.");

                double value = double.Parse(elements[0]);
                string clientSector = elements[1];
                DateTime nextPaymentDate = DateTime.ParseExact(elements[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                trades.Add(new Trade(value, clientSector, nextPaymentDate));
            }

            if (trades.Count != quantityTrades)
                throw new InvalidDataException("Number of trades read does not match the value reported.");

            return new Portfolio(referenceDate, quantityTrades, trades);
        }
    }
}