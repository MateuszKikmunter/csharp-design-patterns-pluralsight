namespace StrategyPattern.Business.Models.Strategies.Abstract
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
