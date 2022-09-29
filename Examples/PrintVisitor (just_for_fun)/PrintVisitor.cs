using Geometry.Visitors;
using Geometry.Strategies;

namespace Examples
{
    public class PrintVisitor : FigureVisitor<string>
    {
        public PrintVisitor()
        {
            StrategyContainer.Register<ICircleStrategy<string>>(new CirclePrintStrategy());
            StrategyContainer.Register<ITriangleStrategy<string>>(new TrianglePrintStrategy());
            StrategyContainer.Register<IRectangleStrategy<string>>(new RectanglePrintStrategy());
        }
    }
}
