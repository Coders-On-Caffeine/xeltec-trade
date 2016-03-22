
namespace XeltecTradeTests
{
    using System;

    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces.TradeResources;
    using Xeltec.Trade.TradeResources;

    using Moq;
    using Moq.AutoMock;
    using Xunit;
    
    public class ProductionRequiresTests
    {
        private AutoMocker autoMocker;

        public ProductionRequiresTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanCreateProductionRequired()
        {
            var mockTradeItem = autoMocker.GetMock<ITradeItem>();
            var stubQuantityRequired = 1;

            var sut = new Mock<ProductionRequires>(mockTradeItem, stubQuantityRequired);
            Assert.NotNull(sut);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenPassedNullTradeItem()
        {
            autoMocker.Use<ITradeItem>((ITradeItem)null);
            autoMocker.Use<Int32>(1);

            var exception = Record.Exception(() => autoMocker.CreateInstance<ProductionRequires>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentNullException>(exception);
            Assert.Equal("itemRequired", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenPassedZeroQuantityRequired()
        {
            autoMocker.Use<Int32>(0);

            var exception = Record.Exception(() => autoMocker.CreateInstance<ProductionRequires>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantityRequired", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenPassedNegativeQuantityRequired()
        {
            autoMocker.Use<Int32>(-1);

            var exception = Record.Exception(() => autoMocker.CreateInstance<ProductionRequires>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantityRequired", ((ArgumentOutOfRangeException)exception).ParamName);
        }


        [Fact]
        public void UsesProvidedTradeItem()
        {
            var stubPower = new Power();
            autoMocker.Use<ITradeItem>(stubPower);
            autoMocker.Use<Int32>(1);

            var sut = autoMocker.CreateInstance<ProductionRequires>();

            Assert.Equal(stubPower, sut.ItemRequired);
        }

        [Fact]
        public void UsesProvidedQuantityRequired()
        {
            var stubQuantityRequired = 1;
            autoMocker.Use<Int32>(stubQuantityRequired);

            var sut = autoMocker.CreateInstance<ProductionRequires>();

            Assert.Equal(stubQuantityRequired, sut.QuantityRequired);
        }
    }
}
