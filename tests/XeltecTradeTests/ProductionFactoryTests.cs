
namespace XeltecTradeTests
{
    using System;

    using Xeltec.Trade.Interfaces.Factories;
    using Xeltec.Trade.Interfaces.TradeResources;
    using Xeltec.Trade.Factories;
    using Xeltec.Trade.TradeResources;

    using Moq.AutoMock;
    using Xunit;
    
    public class ProductionFactoryTests
    {
        private AutoMocker autoMocker;

        public ProductionFactoryTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanConstructProductionFactory()
        {
            var sut = autoMocker.CreateInstance<ProductionFactory>();
            Assert.NotNull(sut);
        }

        [Fact]
        public void ProductionFactoryCanBeCastToExpectedInterface()
        {
            var sut = autoMocker.CreateInstance<ProductionFactory>();
            Assert.IsAssignableFrom<IProductionFactory<ITradeItem>>(sut);
        }

        [Fact]
        public void CreateReturnsProductionWithTradeItemOfExpectedType()
        {
            var sut = autoMocker.CreateInstance<ProductionFactory>();
            var stubPower = new Power();

            var result = sut.Create(stubPower);

            Assert.IsAssignableFrom<Power>(result.TradeItem);
        }

        [Fact]
        public void CreateThrowsArgumentNullExceptionWhenPassedNullTradeItem()
        {
            var sut = autoMocker.CreateInstance<ProductionFactory>();
            var stubTradeItem = (ITradeItem)null;

            var exception = Record.Exception(() => sut.Create(stubTradeItem));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentNullException>(exception);
            Assert.Equal("tradeItemProduced", ((ArgumentNullException)exception).ParamName);
        }
    }
}
