
namespace Xeltec.Trade.Interfaces
{
    public interface ILocation
    {
        int X { get; }
        int Y { get; }
        double CalculateDistanceToLocation(ILocation location);
    }
}