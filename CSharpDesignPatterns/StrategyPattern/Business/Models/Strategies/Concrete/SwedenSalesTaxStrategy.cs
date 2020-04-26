namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
