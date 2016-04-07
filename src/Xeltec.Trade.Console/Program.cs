
namespace Xeltec.Trade.Console
{
    using System;
    using System.Linq;

    using Xeltec.Trade.Factories;
    using Xeltec.Trade.Interfaces;

    public class Program
    {
        private ITradeNetwork TradeNetwork;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Execute();
        }
        
        public Program()
        {
            var ResourceFactoryFactory = new ResourceFactoryFactory();
            
            var factoryList = ResourceFactoryFactory.CreateRandom(10);

            TradeNetwork = new TradeNetwork(factoryList);
            TradeNetwork.CalculatePricesForTradeNetwork();            
        }

        public void Execute()
        {
            Console.WriteLine("Welcome to Xeltec Trade Network");
            PrintTradeNetworkInfo();
            TradeNetwork.Tick();
            PrintTradeNetworkInfo();
            while(Console.ReadKey().Key != ConsoleKey.X)
            {
                TradeNetwork.Tick();
                PrintTradeNetworkInfo();
            }
        }

        private void PrintTradeNetworkInfo()
        {
            Console.Clear();
            foreach(var f in TradeNetwork.Factories)
            {
                Console.WriteLine(string.Format("Factory at [{0},{1}] has Credits: {2}", f.Location.X, f.Location.Y, f.Credits));
                foreach(var resourceProduced in f.Production)
                {
                    Console.WriteLine(String.Format(" - Makes {0} units of {1}", resourceProduced.UnitsProducedPerTick, resourceProduced.ItemProduced.Description));
                    foreach(var productionRequires in resourceProduced.ProductionRequires)
                    {
                        Console.WriteLine(String.Format(" -- Requires {0} units of {1}", productionRequires.QuantityRequired, productionRequires.ItemRequired.Description));
                    }
                }
                PrintFactoryTradableStock(f);
            }
        }

        private void PrintFactoryTradableStock(IResourceFactory resourceFactory)
        {
            Console.WriteLine(string.Format(" -- Tradable Stock -- "));
            foreach(var tradeItem in resourceFactory.TradableStockItems)
            {
                var storage = resourceFactory.ResourceStorage.First(item => item.TradeItem.GetType() == tradeItem.TradeItem.GetType());
                Console.WriteLine(string.Format(" -- {0} : [{1}/{2}] : {3}", tradeItem.TradeItem.Description, tradeItem.QuantityInStock, storage.StorageCapacity, tradeItem.PricePerUnit));
            }
        }
    }
}
