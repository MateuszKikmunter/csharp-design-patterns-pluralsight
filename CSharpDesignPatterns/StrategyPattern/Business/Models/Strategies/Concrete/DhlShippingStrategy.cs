using StrategyPattern.Business.Models.Strategies.Abstract;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
