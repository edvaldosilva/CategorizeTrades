using CategorizeTrades.Application.Interfaces;
using CategorizeTrades.Domain.Interfaces;

namespace CategorizeTrades.Application.Services
{
    public class HighRiskCategory : ICategory
    {
        public string Classify(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private" ? "HIGHRISK" : null;
        }
    }
}
