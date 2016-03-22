

namespace Xeltec.Trade.Interfaces
{
    using Xeltec.Trade.Interfaces.TradeResources;

    public interface IProductionRequires
    {
        ITradeItem ItemRequired { get; }
        int QuantityRequired { get; }
    }
}
