
namespace Xeltec.Trade
{
    using System;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Storage : IStorage
    {
        public Storage(ITradeItem tradeItem)
        {
            StorageLevel = 1;
            TradeItem = tradeItem;
        }

        private int A = 2;
        private int B = 4;
        private int C = 0;
        private int D = 94;

        public int StorageLevel { get; set; }
        public int StorageCapacity => (int)((A * Math.Pow(StorageLevel, 3) + (B * Math.Pow(StorageLevel, 2) + (C * StorageLevel) + D)));

        public ITradeItem TradeItem
        {
            get; private set;
        }
    }
}
