
namespace Geometry
{
    public interface IFigure
    {
        T Accept<T>(IStrategyResolver strategyResolver);
    }
}
