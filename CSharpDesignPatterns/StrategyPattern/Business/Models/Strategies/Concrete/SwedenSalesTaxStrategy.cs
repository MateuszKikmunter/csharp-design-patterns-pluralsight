using System.Collections.Generic;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {    
        public decimal GetTaxFor(Order order)
        {
            var totalTax = 0m;

            foreach (var item in order.LineItems)
            {
                switch (item.Key.ItemType)
                {
                    case Enums.ItemType.Food:
                        totalTax += ApplyTax(item, 0.06m);
                        break;
                    case Enums.ItemType.Literature:
                        totalTax += ApplyTax(item, 0.08m);
                        break;
                    case Enums.ItemType.Hardware:
                    case Enums.ItemType.Service:
                        totalTax += ApplyTax(item, 0.25m);
                        break;
                }
            }

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();

            if (destination.Equals(origin))
            {
                return order.TotalPrice * 0.25m;
            }

            return 0;
        }

        private decimal ApplyTax(KeyValuePair<Item, int> item, decimal taxRate) => (item.Key.Price * taxRate) * item.Value;
    }
}
