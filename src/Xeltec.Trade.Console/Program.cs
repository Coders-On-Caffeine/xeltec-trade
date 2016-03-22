
namespace Xeltec.Trade.Console
{
    using System;

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
        }

        public void Execute()
        {
            Console.WriteLine("Welcome to Xeltec Trade Network");
            PrintTradeNetworkInfo();
            Console.ReadKey();
        }

        private void PrintTradeNetworkInfo()
        {
            foreach(var f in TradeNetwork.Factories)
            {
                Console.WriteLine(string.Format("Factory at [{0},{1}] has Credits: {2}", f.Location.X, f.Location.Y, f.Credits));
                foreach(var resourceProduced in f.Production)
                {
                    Console.WriteLine(String.Format(" - Makes {0} units of {1}", resourceProduced.UnitsProducedPerTick, resourceProduced.TradeItem.Description));
                }
            }
        }
    }
}
