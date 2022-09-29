using Geometry;
using Geometry.Figures;
using Geometry.Internals;
using Geometry.Strategies;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class CircleTests
    {
        [TestCase(-Constants.Accuracy - 1, TestName = "NegativeRadius")]
        [TestCase(0, TestName = "ZeroRadius")]
        [TestCase(Constants.Accuracy / 2, TestName = "ZeroRadiusWithAccuracy")]
        public void ValidateIllegalArgumentsTest(double radius)
        {
            Assert.Throws<ArgumentException>(() => Circle.Create(radius));
        }

        [Test]
        public void CreatedCircleIsCorrectTest()
        {
            double radius = 5;
            var circle = Circle.Create(radius);

            Assert.That(circle.Radius, Is.EqualTo(radius).Within(1e-5));
        }

        [Test]
        public void AcceptMethodTest()
        {
            ResolveMethodWasCalledWithCorrectParametersTest<int>();
            ResolveMethodWasCalledWithCorrectParametersTest<Mock>();
        }

        private void ResolveMethodWasCalledWithCorrectParametersTest<T>()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);
            double radius = 5;
            var circle = Circle.Create(radius);

            var resolver = repository.Create<IStrategyResolver>();
            var strategy = repository.Create<ICircleStrategy<T>>();

            strategy.Setup(s => s.Execute(circle)).Returns(It.IsAny<T>());
            resolver.Setup(r => r.Resolve<ICircleStrategy<T>>()).Returns(strategy.Object);

            circle.Accept<T>(resolver.Object);

            resolver.Verify(r => r.Resolve<ICircleStrategy<T>>());
        }
    }
}