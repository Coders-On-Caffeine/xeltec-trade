
namespace Xeltec.Trade
{
    using System;
    using Xeltec.Trade.Interfaces;

    public class Location : ILocation
    {
        public Location (int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get; private set;
        }

        public int Y
        {
            get; private set;
        }

        public double CalculateDistanceToLocation(ILocation location)
        {
            var distanceX = location.X - X;
            var distanceY = location.Y - Y;
            var distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }
    }
}
