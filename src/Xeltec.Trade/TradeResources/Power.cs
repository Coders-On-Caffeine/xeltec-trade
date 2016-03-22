
namespace Xeltec.Trade.TradeResources
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Power : ITradeItem
    {
        public string Description => "Power";
        public double Weight => 2.0;
        public double Size => 1.0;
    }
}
