
namespace XeltecTradeTests
{
    using Xeltec.Trade;

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
    }
}
