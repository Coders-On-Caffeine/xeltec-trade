
namespace Xeltec.Trade.Interfaces
{
    public interface IProduction<ITradeItem>
    {
        double UnitsProducedPerTick { get; }
        ITradeItem TradeItem { get; }
    }
}
