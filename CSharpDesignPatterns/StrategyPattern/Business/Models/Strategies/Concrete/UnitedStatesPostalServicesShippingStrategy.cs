using StrategyPattern.Business.Models.Strategies.Abstract;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class UnitedStatesPostalServicesShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                //TODO: Implement USPS shipping integration
                Console.WriteLine("Order is shipped with USPS");
            }
        }
    }
}
