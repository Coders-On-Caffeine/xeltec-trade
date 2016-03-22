
namespace Xeltec.Trade.Interfaces.Factories
{
    using System.Collections.Generic;

    public interface IResourceFactoryFactory
    {
        IResourceFactory Create(IResourceFactoryConfiguration resourceFactoryStartingConfiguration, ILocation location);
        IList<IResourceFactory> CreateRandom(int count);
    }
}