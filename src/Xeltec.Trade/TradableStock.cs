
namespace Xeltec.Trade
{
    using System;

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

        public bool AddStock(double quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }
            QuantityInStock += quantity;

            return true;
        }

        public bool RemoveStock(double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            if(quantity > QuantityInStock)
            {
                return false;
            }

            QuantityInStock -= quantity;

            return true;
        }
    }
}
