using System.Collections.Generic;

namespace Xeltec.Trade
{
    public interface ITradeNetwork
    {
        IList<IResourceFactory> Factories { get; }
    }
}