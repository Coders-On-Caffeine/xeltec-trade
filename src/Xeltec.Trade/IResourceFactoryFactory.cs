using System.Collections.Generic;

namespace Xeltec.Trade
{
    public interface IResourceFactoryFactory
    {
        IResourceFactory Create(IResourceFactoryConfiguration resourceFactoryStartingConfiguration, ILocation location);
        IList<IResourceFactory> CreateRandom(int count);
    }
}