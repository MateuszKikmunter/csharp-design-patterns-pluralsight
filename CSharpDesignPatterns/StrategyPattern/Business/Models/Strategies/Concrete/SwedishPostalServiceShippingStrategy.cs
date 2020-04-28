using StrategyPattern.Business.Models.Strategies.Abstract;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                //TODO: Implement DHL shipping integration
                Console.WriteLine("Order is shipped with Swedish Postal Services");
            }
        }
    }
}
