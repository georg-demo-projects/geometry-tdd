using Geometry.Figures;
using Geometry.Strategies;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class TriangleAreaStrategyTests
    {
        [Test]
        public void CaclulateTriangleAreaTest()
        {
            double a = 3;
            double b = 4;
            double c = 5;

            var triangle = new Mock<ITriangle>();
            triangle.Setup(c => c.Side1).Returns(a);
            triangle.Setup(c => c.Side2).Returns(b);
            triangle.Setup(c => c.Side3).Returns(c);

            double expectedArea = 6.0;

            double area = new TriangleAreaStrategy().Execute(triangle.Object);

            Assert.That(area, Is.EqualTo(expectedArea).Within(1e-5));
        }
    }
}
