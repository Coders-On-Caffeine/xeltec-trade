
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xeltec.Trade.Interfaces;

    public class TradeNetwork : ITradeNetwork
    {
        public TradeNetwork(IList<IResourceFactory> resourceFactoryList)
        {
            if (resourceFactoryList == null)
            {
                throw new ArgumentNullException(nameof(resourceFactoryList));
            }
            Factories = resourceFactoryList;
        }

        public IList<IResourceFactory> Factories { get; private set; }

        public void CalculatePricesForTradeNetwork()
        {
            foreach(var f in Factories)
            {
                foreach (var tradeItem in f.TradableStockItems.Where(item => item.TradeItem.GetType() == f.Production.First().ItemProduced.GetType()))
                {
                    // items the factory will sell
                    var storage = f.ResourceStorage.First(item => item.TradeItem.GetType() == tradeItem.TradeItem.GetType());
                    var priceFactor = (Math.Sin((Math.Pow(tradeItem.QuantityInStock/storage.StorageCapacity, 2.0))*Math.PI/2.0)*2.0)-1;
                    tradeItem.PricePerUnit = 50 + ((50 * 0.1) * priceFactor);
                        //(SIN((POW(B35/A35, 2))*PI()/2)*2)-1

                }

            }
        }

        public void Tick()
        {
            foreach(var factory in Factories)
            {
                factory.Tick();
            }

            CalculatePricesForTradeNetwork();
        }
    }
}
