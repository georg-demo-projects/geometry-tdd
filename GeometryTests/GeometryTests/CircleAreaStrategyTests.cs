using Geometry.Figures;
using Geometry.Strategies;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class CircleAreaStrategyTests
    {
        [Test]
        public void CaclulateCircleAreaTest()
        {
            double radius = 10;
            var circle = new Mock<ICircle>();
            circle.Setup(c => c.Radius).Returns(radius);

            double expectedArea = Math.PI * radius * radius;

            double area = new CircleAreaStrategy().Execute(circle.Object);

            Assert.That(area, Is.EqualTo(expectedArea).Within(1e-5));
        }
    }
}
