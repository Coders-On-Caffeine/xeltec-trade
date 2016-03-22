
namespace Xeltec.Trade
{
    using Xeltec.Trade.TradeResources;

    public interface ITradableStock<T>
    {
        double QuantityInStock { get; }
        double PricePerUnit { get; }
        T TradeItem { get; }
    }
}
