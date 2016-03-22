using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeltec.Trade.TradeResources;

namespace Xeltec.Trade
{
    public class TradableStock<T> : ITradableStock<T>
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
