
namespace Xeltec.Trade.Factories
{
    public class LocationFactory : ILocationFactory
    {
        public ILocation Create(int x, int y)
        {
            return new Location(x, y);
        }
    }
}
