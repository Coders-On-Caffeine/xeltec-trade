
namespace XeltecTradeTests
{
    using Xeltec.Trade.Factories;

    using Moq.AutoMock;
    using Xunit;

    public class LocationFactoryTests
    {
        private AutoMocker autoMocker;
        public LocationFactoryTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanCreateLocationFactory()
        {
            var sut = autoMocker.CreateInstance<LocationFactory>();
            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(10, 20)]
        [InlineData(0,0)]
        [InlineData(-10,-20)]
        public void FactoryReturnsLocationWithExpectedCoordinates(int x, int y)
        {
            var sut = autoMocker.CreateInstance<LocationFactory>();
            var result = sut.Create(x, y);
            Assert.Equal(x, result.X);
            Assert.Equal(y, result.Y);
        }
    }
}
