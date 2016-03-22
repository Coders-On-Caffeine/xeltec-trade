
namespace Xeltec.Trade.Interfaces
{
    public interface IProduction<T>
    {
        double UnitsProducedPerTick { get; }
        T TradeItem { get; }
    }
}
