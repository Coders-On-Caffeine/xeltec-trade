
namespace XeltecTradeTests
{
    using System;

    using Xeltec.Trade;
    using Xeltec.Trade.Interfaces;
    using Xeltec.Trade.Interfaces.TradeResources;

    using Moq.AutoMock;
    using Xunit;
    
    public class TradableStockTests
    {
        
        private AutoMocker autoMocker;

        public TradableStockTests()
        {
            autoMocker = new AutoMocker();
        }

        [Fact]
        public void CanCreateTradableStock()
        {
            ITradableStock<ITradeItem> sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(10)]
        public void AddStockAddsProvidedQuantity(int quantity)
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();

            var initialStock = sut.QuantityInStock;
            sut.AddStock(quantity);
            var resultingstock = sut.QuantityInStock;

            Assert.Equal(quantity, resultingstock - initialStock);
        }

        [Fact]
        public void AddStockThrowsArgumentOutOfRangeExceptionWhenQuantityIsZero()
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            var exception = Record.Exception(() => sut.AddStock(0));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantity", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Fact]
        public void AddStockThrowsArgumentOutOfRangeExceotionWhenQuantityIsLessThanZero()
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            var exception = Record.Exception(() => sut.AddStock(-1));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantity", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Theory]
        [InlineData(10)]
        public void RemoveStockRemovesProvidedQuantity(int quantity)
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            sut.AddStock(quantity);

            var initialStock = sut.QuantityInStock;
            sut.RemoveStock(quantity);
            var resultingstock = sut.QuantityInStock;

            Assert.Equal(quantity, initialStock - resultingstock);
        }

        [Fact]
        public void RemoveStockThrowsArgumentOutOfRangeExceptionWhenQuantityIsZero()
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            var exception = Record.Exception(() => sut.RemoveStock(0));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantity", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Fact]
        public void RemoveStockThrowsArgumentOutOfRangeExceotionWhenQuantityIsLessThanZero()
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();
            var exception = Record.Exception(() => sut.RemoveStock(-1));

            Assert.NotNull(exception);
            Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            Assert.Equal("quantity", ((ArgumentOutOfRangeException)exception).ParamName);
        }

        [Fact]
        public void RemoveStockReturnsFalseWhenQuantityInStockIsLessThanQuantityRemoved()
        {
            var sut = autoMocker.CreateInstance<TradableStock<ITradeItem>>();

            var initialStock = sut.QuantityInStock;
            var quantity = initialStock + 1;

            var result = sut.RemoveStock(quantity);
            Assert.False(result);
            Assert.Equal(initialStock, sut.QuantityInStock);
        }
    }
}
