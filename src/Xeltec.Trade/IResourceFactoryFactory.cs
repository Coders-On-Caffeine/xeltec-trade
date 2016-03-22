using System.Collections.Generic;

namespace Xeltec.Trade
{
    public interface IResourceFactoryFactory
    {
        IResourceFactory Create(double startingCredits);
        IList<IResourceFactory> CreateRandom(int count);
    }
}