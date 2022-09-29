using Geometry.Strategies;

namespace Geometry.Visitors
{
    public class AreaFigureVisitor : FigureVisitor<double>
    {
        public AreaFigureVisitor()
        {
            StrategyContainer.Register<ICircleStrategy<double>>(new CircleAreaStrategy());
            StrategyContainer.Register<ITriangleStrategy<double>>(new TriangleAreaStrategy());
        }
    }
}
