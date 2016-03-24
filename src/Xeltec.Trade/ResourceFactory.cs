
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TradeResources;
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class ResourceFactory : IResourceFactory
    {
        public ResourceFactory(IList<IProduction<ITradeItem>> production, IList<ITradableStock<ITradeItem>> tradableStock, IResourceFactoryConfiguration resourceFactoryConfiguration, ILocation location)
        {
            if(production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            if(tradableStock == null)
            {
                throw new ArgumentNullException(nameof(tradableStock));
            }

            if(resourceFactoryConfiguration == null)
            {
                throw new ArgumentNullException(nameof(resourceFactoryConfiguration));
            }

            if(location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            TradableStockItems = tradableStock;
            Production = production;
            Credits = resourceFactoryConfiguration.StartingCredits;
            Location = location;

            ResourceStorage = new List<IStorage>();
            ResourceStorage.Add(new Storage(new Power()));
            ResourceStorage.Add(new Storage(new Water()));
            ResourceStorage.Add(new Storage(new Food()));
        }

        public double Credits { get; set; }

        public IList<IProduction<ITradeItem>> Production { get; private set; }

        public IList<ITradableStock<ITradeItem>> TradableStockItems { get; private set; }

        public ILocation Location { get; private set; }

        public IList<IStorage> ResourceStorage { get; private set; }

        public void AddStock(ITradeItem tradeItem, double quantity)
        {
            TradableStockItems.First(item => item.TradeItem.GetType() == tradeItem.GetType()).AddStock(quantity);
        }

        public void Tick()
        {
            foreach(var item in Production)
            {
                if(!CheckRequiredStockAvailable(item.ProductionRequires) || !CheckStorageHasSpaceForNewStock(item))
                {
                    break;
                }

                TradableStockItems.First(stockItem => stockItem.TradeItem.GetType() == item.ItemProduced.GetType()).AddStock(item.UnitsProducedPerTick);
                UseRequiredStock(item.ProductionRequires);
            }
        }

        private bool CheckStorageHasSpaceForNewStock(IProduction<ITradeItem> itemProduced)
        {
            var currentStock = TradableStockItems.First(item => item.TradeItem.GetType() == itemProduced.ItemProduced.GetType());
            return ResourceStorage.Any(storage => storage.TradeItem.GetType() == itemProduced.ItemProduced.GetType() && (storage.StorageCapacity - currentStock.QuantityInStock) > itemProduced.UnitsProducedPerTick);
        }

        private bool CheckRequiredStockAvailable(IList<IProductionRequires> required)
        {
            foreach(var requiredItem in required)
            {
                if(TradableStockItems.Any(stockItem => stockItem.TradeItem.GetType() == requiredItem.ItemRequired.GetType() && stockItem.QuantityInStock < requiredItem.QuantityRequired))
                {
                    return false;
                }
            }
            return true;
        }

        private void UseRequiredStock(IList<IProductionRequires> requiedItems)
        {
            foreach(var requiredItem in requiedItems)
            {
                TradableStockItems.First(item => item.TradeItem.GetType() == requiredItem.ItemRequired.GetType()).RemoveStock(requiredItem.QuantityRequired);
            }
        }
    }
}
