
namespace Xeltec.Trade
{
    using System;

    using Xeltec.Trade.TradeResources;

    public class Production<ITradeItem> : IProduction<ITradeItem>
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
