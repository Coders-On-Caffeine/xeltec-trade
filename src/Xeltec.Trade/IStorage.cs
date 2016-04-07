
namespace Xeltec.Trade
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public interface IStorage
    {
        int StorageCapacity { get; }
        int StorageLevel { get; set; }
        ITradeItem TradeItem { get; }
    }
}