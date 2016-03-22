
namespace Xeltec.Trade
{
    public interface IProduction<T>
    {
        double UnitsProducedPerTick { get; }
        T TradeItem { get; }
    }
}
