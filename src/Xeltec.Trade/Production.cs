
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Production : IProduction<ITradeItem>
    {
        public Production(ITradeItem itemProduced, double unitsProducedPerTick, IList<IProductionRequires> productionRequires)
        {
            if(itemProduced == null)
            {
                throw new ArgumentNullException(nameof(itemProduced));
            }

            if(unitsProducedPerTick <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unitsProducedPerTick));
            }

            if(productionRequires == null)
            {
                throw new ArgumentNullException(nameof(productionRequires));
            }

            ItemProduced = itemProduced;
            UnitsProducedPerTick = unitsProducedPerTick;
            ProductionRequires = productionRequires;
        }

        public double UnitsProducedPerTick { get; private set; }

        public ITradeItem ItemProduced { get; private set; }

        public IList<IProductionRequires> ProductionRequires { get; private set; }
    }
}
