
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class ResourceFactory : IResourceFactory
    {
        public ResourceFactory(IList<IProduction<ITradeItem>> production, IList<ITradableStock<ITradeItem>> tradableStock, IResourceFactoryConfiguration resourceFactoryConfiguration, ILocation location)
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

            if(location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            TradableStockItems = tradableStock;
            Production = production;
            Credits = resourceFactoryConfiguration.StartingCredits;
            Location = location;
        }

        public double Credits { get; set; }

        public IList<IProduction<ITradeItem>> Production { get; private set; }

        public IList<ITradableStock<ITradeItem>> TradableStockItems { get; private set; }

        public ILocation Location { get; private set; }
    }
}
