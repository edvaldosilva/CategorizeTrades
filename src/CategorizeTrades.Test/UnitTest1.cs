using CategorizeTrades.Application.Interfaces;
using CategorizeTrades.Application.Services;
using CategorizeTrades.Domain.Entities;

namespace CategorizeTrades.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Classify_As_Expired()
        {
            var trade = new Trade(2000000, "Public", DateTime.Now.AddDays(-31));
            var categorizer = new TradeCategorizer(new List<ICategory> { new ExpiredCategory() });
            Assert.Equal("EXPIRED", categorizer.Categorize(trade, DateTime.Now));
        }
        
        [Fact]
        public void Should_Classify_As_HighRisk()
        {
            var trade = new Trade(1000001, "Private", DateTime.Now.AddDays(10));
            var categorizer = new TradeCategorizer(new List<ICategory> { new HighRiskCategory() });
            Assert.Equal("HIGHRISK", categorizer.Categorize(trade, DateTime.Now));
        }

        [Fact]
        public void Should_Classify_As_MediumRisk()
        {
            var trade = new Trade(1000001, "Public", DateTime.Now.AddDays(10));
            var categorizer = new TradeCategorizer(new List<ICategory> { new MediumRiskCategory() });
            Assert.Equal("MEDIUMRISK", categorizer.Categorize(trade, DateTime.Now));
        }
    }
}