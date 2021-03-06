﻿
namespace Xeltec.Trade.Tests
{
    using System;
    using System.Collections.Generic;

    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

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
        public void ThrowsArgumentNullExceptionWhenConstructedWithNullLocation()
        {
            autoMocker.Use<ILocation>((ILocation)null);
            var exception = Record.Exception(() => autoMocker.CreateInstance<ResourceFactory>());

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("location", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void ResourceFactoryUsesProvidedProductionList()
        {
            var mockProduction1 = autoMocker.GetMock<IProduction<ITradeItem>>();
            var mockProduction2 = autoMocker.GetMock<IProduction<ITradeItem>>();

            var stubProductionList = new List<IProduction<ITradeItem>>()
            {
                mockProduction1.Object,
                mockProduction2.Object
            };

            autoMocker.Use<IList<IProduction<ITradeItem>>>(stubProductionList);

            var sut = autoMocker.CreateInstance<ResourceFactory>();

            Assert.Equal(stubProductionList.Count, sut.Production.Count);
            Assert.Contains(mockProduction1.Object, sut.Production);
            Assert.Contains(mockProduction2.Object, sut.Production);
        }

        [Fact]
        public void ResourceFactoryUsesProvidedTradableStockList()
        {
            var mockStockedItem1 = autoMocker.GetMock<ITradableStock<ITradeItem>>();
            var mockStockedItem2 = autoMocker.GetMock<ITradableStock<ITradeItem>>();

            var stubTradedStockList = new List<ITradableStock<ITradeItem>>()
            {
                mockStockedItem1.Object,
                mockStockedItem2.Object
            };

            autoMocker.Use<IList<ITradableStock<ITradeItem>>>(stubTradedStockList);

            var sut = autoMocker.CreateInstance<ResourceFactory>();

            Assert.Equal(stubTradedStockList.Count, sut.TradableStockItems.Count);
            Assert.Contains(mockStockedItem1.Object, sut.TradableStockItems);
            Assert.Contains(mockStockedItem2.Object, sut.TradableStockItems);
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

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(5,10)]
        public void ResourceFactoryUsesProvidedLocation(int x, int y)
        {
            var stubLocation = new Location(x, y);
            autoMocker.Use<ILocation>(stubLocation);

            var sut = autoMocker.CreateInstance<ResourceFactory>();

            Assert.NotNull(sut.Location);
            Assert.Equal(stubLocation, sut.Location);
        }
    }
}
