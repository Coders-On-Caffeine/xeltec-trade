
namespace Xeltec.Trade
{
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Production : IProduction<ITradeItem>
    {
        public Production(ITradeItem tradeItem, double unitsProducedPerTick)
        {
            TradeItem = tradeItem;
            UnitsProducedPerTick = unitsProducedPerTick;
        }

        public double UnitsProducedPerTick
        {
            get; private set;
        }

        public ITradeItem TradeItem { get; private set; }
    }
}
