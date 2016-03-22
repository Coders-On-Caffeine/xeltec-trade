﻿
namespace Xeltec.Trade.TradeResources
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public class Water : ITradeItem
    {
        public string Description => "Water";
        public double Weight => 1.0;
        public double Size => 1.0;
    }
}