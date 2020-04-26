namespace StrategyPattern.Business.Models.Strategies
{
    public interface  ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
