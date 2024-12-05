using CategorizeTrades.Domain.Interfaces;

namespace CategorizeTrades.Application.Interfaces
{
    public interface ICategory
    {
        string Classify(ITrade trade, DateTime referenceDate);
    }
}
