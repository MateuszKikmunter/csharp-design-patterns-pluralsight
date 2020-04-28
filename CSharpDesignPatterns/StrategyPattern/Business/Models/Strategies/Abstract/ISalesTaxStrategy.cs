namespace StrategyPattern.Business.Models.Strategies.Abstract
{
    public interface  ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
