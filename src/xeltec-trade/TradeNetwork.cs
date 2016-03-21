
namespace Xeltec.Trade
{
    using System.Collections.Generic;

    public class TradeNetwork : ITradeNetwork
    {
        public TradeNetwork(IList<IResourceFactory> factories)
        {
            Factories = factories;
        }

        public IList<IResourceFactory> Factories { get; private set; }
    }
}
