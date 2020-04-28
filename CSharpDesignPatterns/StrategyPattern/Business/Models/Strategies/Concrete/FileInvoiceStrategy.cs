using StrategyPattern.Business.Models.Strategies.Abstract;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
