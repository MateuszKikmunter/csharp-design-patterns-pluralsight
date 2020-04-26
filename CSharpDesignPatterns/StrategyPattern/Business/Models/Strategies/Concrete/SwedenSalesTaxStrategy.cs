namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {       
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();

            if (destination.Equals(origin))
            {
                return order.TotalPrice * 0.25m;
            }

            return 0;
        }
    }
}
