
namespace Xeltec.Trade
{
    using System.Collections.Generic;
    using Xeltec.Trade.TradeResources;

    public interface IResourceFactory
    {
        double Credits { get; set; }
        ILocation Location { get; }
        IList<ITradeItem> TradeItems { get; }
        IList<IProduction<ITradeItem>> Production { get; }
    }
}