using Geometry;
using Geometry.Strategies;
using Geometry.Visitors;

namespace GeometryTests
{
    [TestFixture]
    public class AreaVisitorTests
    {
        [Test]
        public void VisitorContainsTheRequiredObjects()
        {
            var visitor = new AreaFigureVisitor();

            var triangleStrategy = visitor.StrategyContainer.Resolve<ITriangleStrategy<double>>();
            var circleStrategy = visitor.StrategyContainer.Resolve<ICircleStrategy<double>>();

            Assert.That(triangleStrategy, Is.Not.Null);
            Assert.That(circleStrategy, Is.Not.Null);
        }
    }
}
