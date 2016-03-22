
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade.TradeResources;

    public class ResourceFactory : IResourceFactory
    {
        public ResourceFactory(IList<IProduction<ITradeItem>> production, IList<ITradableStock<ITradeItem>> tradableStock, IResourceFactoryConfiguration resourceFactoryConfiguration)
        {
            if(production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            if(tradableStock == null)
            {
                throw new ArgumentNullException(nameof(tradableStock));
            }

            if(resourceFactoryConfiguration == null)
            {
                throw new ArgumentNullException(nameof(resourceFactoryConfiguration));
            }

            TradableStockItems = tradableStock;
            Production = production;
            Credits = resourceFactoryConfiguration.StartingCredits;
        }

        public double Credits { get; set; }

        public IList<ITradableStock<ITradeItem>> TradableStockItems { get; private set; }

        public IList<IProduction<ITradeItem>> Production { get; private set; }

        public ILocation Location { get; private set; }
    }
}
