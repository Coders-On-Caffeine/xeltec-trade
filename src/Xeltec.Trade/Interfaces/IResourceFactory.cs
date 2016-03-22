
namespace Xeltec.Trade.Interfaces
{
    using System.Collections.Generic;
    using Xeltec.Trade.Interfaces.TradeResources;

    public interface IResourceFactory
    {
        double Credits { get; set; }
        ILocation Location { get; }
        IList<ITradableStock<ITradeItem>> TradableStockItems { get; }
        IList<IProduction<ITradeItem>> Production { get; }
    }
}