using StrategyPattern.Business.Models.Enums;
using StrategyPattern.Business.Models.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public decimal GetTax()
        {
            if(SalesTaxStrategy == null)
            {
                return 0;
            }

            return SalesTaxStrategy.GetTaxFor(this);
        }
    }
}
