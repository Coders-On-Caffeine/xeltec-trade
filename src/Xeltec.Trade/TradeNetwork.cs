
namespace Xeltec.Trade
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade.Interfaces;

    public class TradeNetwork : ITradeNetwork
    {
        public TradeNetwork(IList<IResourceFactory> resourceFactoryList)
        {
            if (resourceFactoryList == null)
            {
                throw new ArgumentNullException(nameof(resourceFactoryList));
            }
            Factories = resourceFactoryList;
        }

        public IList<IResourceFactory> Factories { get; private set; }
    }
}
