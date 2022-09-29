using Geometry.Strategies;

namespace Geometry.Visitors
{
    public class FigureVisitor<T> : IFigureVisitor<T>
    {
        public IStrategyContainer StrategyContainer { get; init; }

        public FigureVisitor()
            : this(new StrategyContainer())
        {
        }

        public FigureVisitor(IStrategyContainer container)
        {
            StrategyContainer = container;
        }

        public T Visit(IFigure figure)
        {
            return figure.Accept<T>(StrategyContainer);
        }
    }
}
