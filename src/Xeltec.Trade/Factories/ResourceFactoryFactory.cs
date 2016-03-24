
namespace Xeltec.Trade.Factories
{
    using System;
    using System.Collections.Generic;
    
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.Factories;
    using Xeltec.Trade.Interfaces.TradeResources;
    using Xeltec.Trade.TradeResources;

    public class ResourceFactoryFactory : IResourceFactoryFactory
    {
        public IResourceFactory Create(IResourceFactoryConfiguration resourceFactoryStartingConfiguration, ILocation location)
        {
            IProduction<ITradeItem> test = new Production(new Power(), 5.0, new List<IProductionRequires>());

            IList<IProduction<ITradeItem>> productionList = new List<IProduction<ITradeItem>>();
            productionList.Add(test);

            var resourceFactory = new ResourceFactory(productionList, null, resourceFactoryStartingConfiguration, location);

            return resourceFactory;
        }

        public IList<IResourceFactory> CreateRandom(int count)
        {
            var resourceFactories = new List<IResourceFactory>();
            var random = new Random(12345);
            var resourceFactoryStartingConfiguration = new ResourceFactoryConfiguration();
            var productionFactory = new ProductionFactory();
            for (int i = 0; i < count; i++)
            {
                var startingCredits = random.Next(5000, 10000);
                IProduction<ITradeItem> test;

                switch (random.Next(1, 4))
                {
                    case 1:

                        test = productionFactory.Create(new Food());
                        break;
                    case 2:
                        test = productionFactory.Create(new Power()); 
                        break;
                    case 3:
                        test = productionFactory.Create(new Water()); 
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                IList<IProduction<ITradeItem>> productionList = new List<IProduction<ITradeItem>>();
                productionList.Add(test);

                IList<ITradableStock<ITradeItem>> tradableStockList = new List<ITradableStock<ITradeItem>>();
                tradableStockList.Add(new TradableStock<ITradeItem>(new Power()));
                tradableStockList.Add(new TradableStock<ITradeItem>(new Water()));
                tradableStockList.Add(new TradableStock<ITradeItem>(new Food()));

                var location = new Location(random.Next(0, 100), random.Next(0, 100));

                var resourceFactory = new ResourceFactory(productionList, tradableStockList, resourceFactoryStartingConfiguration, location);
                resourceFactory.AddStock(new Power(), random.NextDouble() * 99);
                resourceFactory.AddStock(new Water(), random.NextDouble() * 99);
                resourceFactory.AddStock(new Food(), random.NextDouble() * 99);
                resourceFactories.Add(resourceFactory);
            }

            return resourceFactories;
        }
    }
} 
