using CategorizeTrades.Application.Interfaces;
using CategorizeTrades.Domain.Interfaces;

namespace CategorizeTrades.Application.Services
{
    public class TradeCategorizer
    {
        private readonly IEnumerable<ICategory> _categories;

        public TradeCategorizer(IEnumerable<ICategory> categories)
        {
            _categories = categories;
        }

        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            foreach (var category in _categories)
            {
                var result = category.Classify(trade, referenceDate);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            return "UNCATEGORIZED";
        }
    }
}
