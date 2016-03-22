
namespace Xeltec.Trade
{
    using System.Collections.Generic;

    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Production : IProduction<ITradeItem>
    {
        public Production(ITradeItem tradeItem, double unitsProducedPerTick, IList<IProductionRequires> productionRequires)
        {
            TradeItem = tradeItem;
            UnitsProducedPerTick = unitsProducedPerTick;
        }

        public double UnitsProducedPerTick { get; private set; }

        public ITradeItem TradeItem { get; private set; }

        public IList<IProductionRequires> ProductionRequires { get; private set; }
    }
}
