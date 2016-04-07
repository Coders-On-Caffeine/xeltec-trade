
namespace Xeltec.Trade.Tests
{
    using Xeltec.Trade.Interfaces.TradeResources;
    using Xeltec.Trade.TradeResources;

    using Moq.AutoMock;
    using Xunit;

    public class PowerTests
    {
        private AutoMocker autoMocker;

        public PowerTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanConstructPower()
        {
            var sut = autoMocker.CreateInstance<Power>();
            Assert.NotNull(sut);
        }

        [Fact]
        public void ImplementsExpectedInterface()
        {
            var sut = autoMocker.CreateInstance<Power>();
            Assert.IsAssignableFrom<ITradeItem>(sut);
        }
    }
}
