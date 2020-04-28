namespace StrategyPattern.Business.Models.Strategies.Abstract
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
