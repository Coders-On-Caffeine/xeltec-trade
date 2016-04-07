

namespace Xeltec.Trade.Interfaces
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public interface ITradableStock<T> where T : ITradeItem
    {
        double QuantityInStock { get; }
        double PricePerUnit { get; set; }
        T TradeItem { get; }

        bool AddStock(double quantity);
        bool RemoveStock(double quantity);
    }
}
