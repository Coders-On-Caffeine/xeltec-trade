

namespace Xeltec.Trade.Factories
{
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.Factories;

    public class LocationFactory : ILocationFactory
    {
        public ILocation Create(int x, int y)
        {
            return new Location(x, y);
        }
    }
}
