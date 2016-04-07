
namespace Xeltec.Trade.Tests
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces;

    using Moq.AutoMock;
    using Xunit;
    using Xeltec.Trade.Interfaces.TradeResources;
    public class ProductionTests
    {
        private AutoMocker autoMocker;

        public ProductionTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanCreateProduction()
        {
            autoMocker.Use<Double>(1);

            var sut = autoMocker.CreateInstance<Production>();
            Assert.NotNull(sut);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenPassedNullItemProduced()
        {
            autoMocker.Use<ITradeItem>((ITradeItem)null);
            autoMocker.Use<Double>(1);

            var exception = Record.Exception(() => autoMocker.CreateInstance<Production>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentNullException>(exception);
            Assert.Equal("itemProduced", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenPassedZeroUnitsProducedPerTick()
        {
            autoMocker.Use<Double>(0);

            var exception = Record.Exception(() => autoMocker.CreateInstance<Production>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("unitsProducedPerTick", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenPassedNullProductionRequiresList()
        {
            autoMocker.Use<IList<IProductionRequires>>((IList<IProductionRequires>)null);
            autoMocker.Use<Double>(1);

            var exception = Record.Exception(() => autoMocker.CreateInstance<Production>());

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentNullException>(exception);
            Assert.Equal("productionRequires", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void UsesProvidedItemProduced()
        {
            var mockItemProduced = autoMocker.GetMock<ITradeItem>();
            autoMocker.Use<Double>(1);

            var sut = autoMocker.CreateInstance<Production>();

            Assert.Equal(mockItemProduced.Object, sut.ItemProduced);
        }

        [Fact]
        public void UsesProvidedUnitsProducedPerTick()
        {
            var stubUnitsProducedPerTick = 5;
            autoMocker.Use<Double>(stubUnitsProducedPerTick);

            var sut = autoMocker.CreateInstance<Production>();

            Assert.Equal(stubUnitsProducedPerTick, sut.UnitsProducedPerTick);
        }

        [Fact]
        public void UsesProvidedProductionRequires()
        {
            var mockItemRequired = autoMocker.GetMock<IProductionRequires>();
            var stubProductionRequires = new List<IProductionRequires>() {
                mockItemRequired.Object
            };

            autoMocker.Use<Double>(1);
            autoMocker.Use<IList<IProductionRequires>>(stubProductionRequires);

            var sut = autoMocker.CreateInstance<Production>();

            Assert.Equal(stubProductionRequires, sut.ProductionRequires);
        }
    }
}
