using CategorizeTrades.Application.Interfaces;
using CategorizeTrades.Domain.Interfaces;

namespace CategorizeTrades.Application.Services
{
    public class ExpiredCategory : ICategory
    {
        public string Classify(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).Days > 30 ? "EXPIRED" : null;
        }
    }
}
