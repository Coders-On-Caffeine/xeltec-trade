
namespace Xeltec.Trade.Tests
{
    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces;

    using Moq;
    using Moq.AutoMock;
    using Xunit;
    
    public class LocationTests
    {
        private AutoMocker autoMocker;

        public LocationTests()
        {
            this.autoMocker = new AutoMocker(MockBehavior.Loose);
        }

        [Fact]
        public void CanConstructLocation()
        {
            int stubX = 0;
            int stubY = 0;
            var sut = new Mock<Location>(stubX, stubY);
            Assert.NotNull(sut.Object);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 2)]
        public void LocationUsesProvidedCoordinates(int x, int y)
        {
            var sut = new Mock<Location>(x, y);

            Assert.Equal(x, sut.Object.X);
            Assert.Equal(y, sut.Object.Y);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 1)]
        [InlineData(0, 0, 1, 0, 1)]
        [InlineData(0, 0, 3, 4, 5)]
        [InlineData(1, 1, 1, 1, 0)]
        public void CanDetermineDistanceBetweenLocations(int x1, int y1, int x2, int y2, double expectedDistance)
        {
            var sut = new Mock<Location>(x1, y1);
            var mockLocation = autoMocker.GetMock<ILocation>();

            mockLocation.Setup(x => x.X).Returns(x2);
            mockLocation.Setup(o => o.Y).Returns(y2);

            var result = sut.Object.CalculateDistanceToLocation(mockLocation.Object);

            Assert.Equal(expectedDistance, result);
        }
    }
}
