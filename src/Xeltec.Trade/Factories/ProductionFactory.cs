
namespace Xeltec.Trade.Factories
{
    using System;

    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.Factories;
    using Xeltec.Trade.Interfaces.TradeResources;
    using Xeltec.Trade.TradeResources;

    public class ProductionFactory : IProductionFactory<ITradeItem>
    {
        public IProduction<ITradeItem> Create(ITradeItem tradeItemProduced)
        {
            if(tradeItemProduced == null)
            {
                throw new ArgumentNullException(nameof(tradeItemProduced));
            }

            IProduction<ITradeItem> productionItem = null;
            switch(tradeItemProduced.GetType().Name)
            {
                case nameof(Power):
                    productionItem = new Production(tradeItemProduced, 2);
                    break;
                case nameof(Water):
                    productionItem = new Production(tradeItemProduced, 4);
                    break;
                case nameof(Food):
                    productionItem = new Production(tradeItemProduced, 5);
                    break;
                default:
                    throw new ArgumentException("Unexpected Argument", nameof(tradeItemProduced));
            }

            return productionItem;
        }
    }
}
