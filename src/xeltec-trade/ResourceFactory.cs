
namespace Xeltec.Trade
{
    using System.Collections.Generic;

    using Xeltec.Trade.TradeResources;

    public class ResourceFactory : IResourceFactory
    {
        public ResourceFactory(IList<IProduction<ITradeItem>> production, double startingCredits)
        {
            TradeItems = new List<ITradeItem>();
            Production = production;
            Credits = startingCredits;
        }

        public double Credits { get; set; }

        public IList<ITradeItem> TradeItems { get; private set; }

        public IList<IProduction<ITradeItem>> Production { get; private set; }

        public ILocation Location { get; private set; }

    }
}
