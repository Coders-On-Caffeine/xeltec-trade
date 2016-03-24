
namespace Xeltec.Trade.Interfaces
{
    using System.Collections.Generic;

    public interface IProduction<ITradeItem>
    {
        double UnitsProducedPerTick { get; }
        ITradeItem ItemProduced { get; }
        IList<IProductionRequires> ProductionRequires { get; }
    }
}
