using System.Collections.Generic;

namespace Xeltec.Trade
{
    public interface IResourceFactoryFactory
    {
        IResourceFactory Create(IResourceFactoryConfiguration resourceFactoryStartingConfiguration);
        IList<IResourceFactory> CreateRandom(int count);
    }
}