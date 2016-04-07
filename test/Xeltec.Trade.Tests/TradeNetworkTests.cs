


namespace Xeltec.Trade.Tests
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces;

    using Moq.AutoMock;
    using Xunit;
    
    public class TradeNetworkTests
    {
        private AutoMocker autoMocker;

        public TradeNetworkTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanConstructTradeNetwork()
        {
            var sut = autoMocker.CreateInstance<TradeNetwork>();
            Assert.NotNull(sut);
        }

        [Fact]
        public void TradeNetworkReturnsExpectedListOfFactories()
        {
            var resourceFactory1 = autoMocker.GetMock<IResourceFactory>();
            var resourceFactory2 = autoMocker.GetMock<IResourceFactory>();

            IList<IResourceFactory> stubResourceFactoryList = new List<IResourceFactory>()
            {
                resourceFactory1.Object,
                resourceFactory2.Object
            };

            autoMocker.Use<IList<IResourceFactory>>(stubResourceFactoryList);

            var sut = autoMocker.CreateInstance<TradeNetwork>();

            Assert.Contains(resourceFactory1.Object, sut.Factories);
            Assert.Contains(resourceFactory2.Object, sut.Factories);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionIfInjectedResourceFactoryListIsNull()
        {
            autoMocker.Use<IList<IResourceFactory>>((IList<IResourceFactory>)null);

            var exception = Record.Exception(() => autoMocker.CreateInstance<TradeNetwork>());

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("resourceFactoryList", ((ArgumentNullException)exception).ParamName);
        }
    }
}
