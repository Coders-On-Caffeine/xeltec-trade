
namespace Xeltec.Trade
{
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class TradableStock<T> : ITradableStock<T> where T : ITradeItem
    {
        public TradableStock(T tradeItem)
        {
            TradeItem = tradeItem;
        }

        public double PricePerUnit
        {
            get; private set;
        }

        public double QuantityInStock
        {
            get; private set;
        }

        public T TradeItem
        {
            get; private set;
        }
    }
}
