namespace Xeltec.Trade.Interfaces.Factories
{
    public interface ILocationFactory
    {
        ILocation Create(int x, int y);
    }
}