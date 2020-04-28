using StrategyPattern.Business.Models.Strategies.Abstract;
using System;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class UPSShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
