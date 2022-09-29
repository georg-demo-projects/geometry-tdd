
namespace Geometry
{
    public interface IFigureVisitor<T>
    {
        IStrategyContainer StrategyContainer { get; }

        T Visit(IFigure figure);
    }
}
