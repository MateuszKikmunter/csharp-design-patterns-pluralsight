using StrategyPattern.Business.Models.Strategies.Abstract;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    class FedexShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                //TODO: Implement Fedex shipping integration
                Console.WriteLine("Order is shipped with Fedex");
            }
        }
    }
}
