namespace CategorizeTrades.Domain.Interfaces
{
    public interface IPortfolio
    {
        DateTime ReferenceDate { get; }
        int QuantityTrades { get; }
        List<ITrade> Trades { get; }
    }
}
