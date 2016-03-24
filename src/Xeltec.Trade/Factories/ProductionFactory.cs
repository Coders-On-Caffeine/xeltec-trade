
namespace Xeltec.Trade.Factories
{
    using System;
    using System.Collections.Generic;

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
                    var powerProductionRequires = new List<IProductionRequires>()
                    {
                        new ProductionRequires(new Water(), 1),
                        new ProductionRequires(new Food(), 1)
                    };

                    productionItem = new Production(tradeItemProduced, 2, powerProductionRequires);
                    break;
                case nameof(Water):
                    var waterProductionRequires = new List<IProductionRequires>()
                    {
                        new ProductionRequires(new Food(), 1),
                        new ProductionRequires(new Power(), 1)
                    };

                    productionItem = new Production(tradeItemProduced, 4, waterProductionRequires);
                    break;
                case nameof(Food):
                    var foodProductionRequires = new List<IProductionRequires>()
                    {
                        new ProductionRequires(new Water(), 1),
                        new ProductionRequires(new Power(), 1)
                    };

                    productionItem = new Production(tradeItemProduced, 5, foodProductionRequires);
                    break;
                default:
                    throw new ArgumentException("Unexpected Argument", nameof(tradeItemProduced));
            }

            return productionItem;
        }
    }
}
