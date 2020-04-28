using StrategyPattern.Business.Models.Strategies.Abstract;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
