namespace Xeltec.Trade
{
    public interface ILocationFactory
    {
        ILocation Create(int x, int y);
    }
}