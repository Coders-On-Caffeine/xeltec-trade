
namespace Xeltec.Trade
{
    using System;

    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    public class ProductionRequires : IProductionRequires
    {
        public ProductionRequires(ITradeItem itemRequired, int quantityRequired)
        {
            if(itemRequired == null)
            {
                throw new ArgumentNullException(nameof(itemRequired));
            }

            if(quantityRequired <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantityRequired));
            }

            ItemRequired = itemRequired;
            QuantityRequired = quantityRequired;
        }

        public ITradeItem ItemRequired
        {
            get; private set;
        }

        public int QuantityRequired
        {
            get; private set;
        }
    }
}
