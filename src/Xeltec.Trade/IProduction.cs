
namespace Xeltec.Trade
{
    public interface IProduction<ITradeItem>
    {
        double UnitsProducedPerTick { get; }
        ITradeItem TradeItem { get; }
    }
}
