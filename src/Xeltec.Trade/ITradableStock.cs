
namespace Xeltec.Trade
{
    public interface ITradableStock<ITradeItem>
    {
        double QuantityInStock { get; }
        double PricePerUnit { get; }
        ITradeItem TradeItem { get; }
    }
}
