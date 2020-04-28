using StrategyPattern.Business.Models.Strategies.Abstract;
using System;
using System.IO;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (var stream = new StreamWriter($"invoice_{ Guid.NewGuid() }.txt"))
            {
                stream.Write(GenerateTextInvoice(order));
                stream.Flush();
            }
        }
    }
}
