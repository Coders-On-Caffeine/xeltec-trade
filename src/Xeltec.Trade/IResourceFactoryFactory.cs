using System.Collections.Generic;

namespace Xeltec.Trade
{
    public interface IResourceFactoryFactory
    {
        IResourceFactory Create(IResourceFactoryStartingConfiguration resourceFactoryStartingConfiguration);
        IList<IResourceFactory> CreateRandom(int count);
    }
}