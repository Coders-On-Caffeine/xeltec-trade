﻿
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

    }
}
