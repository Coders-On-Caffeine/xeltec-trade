
namespace Xeltec.Trade.TradeResources
{
    public interface ITradeItem
    {
        string Description { get; }
        double Weight { get; }
        double Size { get; }
    }
}
