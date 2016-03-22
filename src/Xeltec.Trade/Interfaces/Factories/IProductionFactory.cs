
namespace Xeltec.Trade.Interfaces.Factories
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public interface IProductionFactory<T> where T : ITradeItem
    {
        IProduction<T> Create(T tradeItemProduced);
    }
}
