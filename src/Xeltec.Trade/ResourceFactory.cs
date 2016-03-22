
namespace Xeltec.Trade
{
    using System.Collections.Generic;

    using Xeltec.Trade.TradeResources;

    public class ResourceFactory : IResourceFactory
    {
        public ResourceFactory(IList<IProduction<ITradeItem>> production, IList<ITradableStock<ITradeItem>> tradableStock, IResourceFactoryStartingConfiguration resourceFactoryStartingConfiguration)
        {
            TradableStockItems = tradableStock;
            Production = production;
            Credits = resourceFactoryStartingConfiguration.StartingCredits;
        }

        public double Credits { get; set; }

        public IList<ITradableStock<ITradeItem>> TradableStockItems { get; private set; }

        public IList<IProduction<ITradeItem>> Production { get; private set; }

        public ILocation Location { get; private set; }
    }
}
