using CategorizeTrades.Domain.Interfaces;

namespace CategorizeTrades.Domain.Entities
{
    public class Portfolio : IPortfolio
    {
        public DateTime ReferenceDate { get; private set; }
        public int QuantityTrades { get; private set; }
        public List<ITrade> Trades { get; private set; }

        public Portfolio(DateTime referenceDate, int quantityTrades, List<ITrade> trades)
        {
            ReferenceDate = referenceDate;
            QuantityTrades = quantityTrades;
            Trades = trades;
        }
    }
}
