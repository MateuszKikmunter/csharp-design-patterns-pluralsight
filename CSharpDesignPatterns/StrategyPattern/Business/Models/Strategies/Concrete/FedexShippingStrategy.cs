using StrategyPattern.Business.Models.Strategies.Abstract;
using System;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    class FedexShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
