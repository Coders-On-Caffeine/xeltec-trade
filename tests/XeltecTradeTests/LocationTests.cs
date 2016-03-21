using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeltecTradeTests
{
    using Xeltec.Trade;

    using Moq.AutoMock;
    using Xunit;

    public class LocationTests
    {
        private AutoMocker autoMocker;

        public LocationTests()
        {
            this.autoMocker = new AutoMocker();
        }

        public void CanConstructLocation()
        {
            var sut = autoMocker.CreateInstance<ILocation>();
            Assert.NotNull(sut);
        }
    }
}
