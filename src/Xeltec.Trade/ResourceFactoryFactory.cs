

using System;
using System.Collections.Generic;
using Xeltec.Trade.TradeResources;

namespace Xeltec.Trade
{
    public class ResourceFactoryFactory : IResourceFactoryFactory
    {
        public IResourceFactory Create(double startingCredits)
        {
            IProduction<ITradeItem> test = new Production<ITradeItem>(new Power(), 5.0);

            IList<IProduction<ITradeItem>> productionList = new List<IProduction<ITradeItem>>();
            productionList.Add(test);

            var resourceFactory = new ResourceFactory(productionList, null, startingCredits);

            return resourceFactory;
        }

        public IList<IResourceFactory> CreateRandom(int count)
        {
            var resourceFactories = new List<IResourceFactory>();
            var random = new Random(12345);

            for (int i = 0; i < count; i++)
            {
                var startingCredits = random.Next(5000, 10000);
                IProduction<ITradeItem> test;

                switch (random.Next(1, 4))
                {
                    case 1:
                        test = new Production<ITradeItem>(new Food(), random.Next(1, 10));
                        break;
                    case 2:
                        test = new Production<ITradeItem>(new Power(), random.Next(1, 10));
                        break;
                    case 3:
                        test = new Production<ITradeItem>(new Water(), random.Next(1, 10));
                        break;
                    default:
                        test = null;
                        break;
                }

                IList<IProduction<ITradeItem>> productionList = new List<IProduction<ITradeItem>>();
                productionList.Add(test);

                IList<ITradableStock<ITradeItem>> tradableStockList = new List<ITradableStock<ITradeItem>>();
                tradableStockList.Add(new TradableStock<ITradeItem>(new Power()));

                var resourceFactory = new ResourceFactory(productionList, tradableStockList, startingCredits);
                resourceFactories.Add(resourceFactory);
            }

            return resourceFactories;
        }
    }
}
