
namespace Xeltec.Trade.Interfaces
{
    using System.Collections.Generic;

    public interface ITradeNetwork
    {
        IList<IResourceFactory> Factories { get; }
    }
}