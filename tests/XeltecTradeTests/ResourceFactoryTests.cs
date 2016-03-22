
namespace XeltecTradeTests
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade;
    using Xeltec.Trade.TradeResources;

    using Moq.AutoMock;
    using Xunit;

    public class ResourceFactoryTests
    {
        private AutoMocker autoMocker;

        public ResourceFactoryTests()
        {
            autoMocker = new AutoMocker(Moq.MockBehavior.Loose);
        }

        [Fact]
        public void CanConstructResourceFactory()
        {
            var sut = autoMocker.CreateInstance<ResourceFactory>();
            Assert.NotNull(sut);
        }

        [Fact]
        public void ResourceFactoryImplementsExpectedInterface()
        {
            var sut = autoMocker.CreateInstance<ResourceFactory>();
            Assert.IsAssignableFrom<IResourceFactory>(sut);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenConstructedWithNullProductionList()
        {
            autoMocker.Use<IList<IProduction<ITradeItem>>>((IList<IProduction<ITradeItem>>)null);
            var exception = Record.Exception(() => autoMocker.CreateInstance<ResourceFactory>());

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("production", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenConstructedWithNullTradableStockList()
        {
            autoMocker.Use<IList<ITradableStock<ITradeItem>>>((IList<ITradableStock<ITradeItem>>)null);
            var exception = Record.Exception(() => autoMocker.CreateInstance<ResourceFactory>());

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("tradableStock", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenConstructedWithNullResourceFactoryConfiguration()
        {
            autoMocker.Use<IResourceFactoryConfiguration>((IResourceFactoryConfiguration)null);
            var exception = Record.Exception(() => autoMocker.CreateInstance<ResourceFactory>());

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("resourceFactoryConfiguration", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ResourceFactoryUsesStartingCreditsFromProvidedResourceFactoryConfiguration()
        {
            double stubStartingCredits = 100;

            var mockResourceFactoryConfiguration = autoMocker.GetMock<IResourceFactoryConfiguration>();
            mockResourceFactoryConfiguration.Setup(x => x.StartingCredits).Returns(stubStartingCredits);

            var sut = autoMocker.CreateInstance<ResourceFactory>();
            Assert.Equal(stubStartingCredits, sut.Credits);
        }
    }
}
