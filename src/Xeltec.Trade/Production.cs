
namespace Xeltec.Trade
{
    using Xeltec.Trade.TradeResources;

    public class Production<T> : IProduction<T> where T : ITradeItem
    {
        public Production(T tradeItem, double unitsProducedPerTick)
        {
            TradeItem = tradeItem;
            UnitsProducedPerTick = unitsProducedPerTick;
        }

        public double UnitsProducedPerTick
        {
            get; private set;
        }

        public T TradeItem { get; private set; }
    }
}
