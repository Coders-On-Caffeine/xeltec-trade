
namespace Xeltec.Trade
{
    public class LocationFactory : ILocationFactory
    {
        public ILocation Create(int x, int y)
        {
            return new Location(x, y);
        }
    }
}
