
namespace Xeltec.Trade.TradeResources
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Food : ITradeItem
    {
        public string Description => "Food";
        public double Weight => 0.5;
        public double Size => 1.0;
    }
}
