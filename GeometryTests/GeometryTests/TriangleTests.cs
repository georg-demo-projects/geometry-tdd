using Geometry;
using Geometry.Figures;
using Geometry.Internals;
using Geometry.Strategies;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class TriangleTests
    {
        MockRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new MockRepository(MockBehavior.Loose);
        }

        [TestCase(2, 2, 4, TestName = "TwoSidesSumIsEqualToRemaining")]
        [TestCase(2, 2, 5, TestName = "TwoSidesSumIsLessThenRemaining")]
        [TestCase(2, 2, 4 - Constants.Accuracy / 2, TestName = "TriangleInequalityViolatedWithAccuracy")]
        public void ValidateIllegalArgumentsTest(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => Triangle.Create(a, b, c));
        }

        [TestCase(3, 4, 5, TestName = "CreatedTriangleIsCorrectTest")]
        [TestCase(2, 2, 3, TestName = "TriangleInequalitySatisfied")]
        [TestCase(2, 2, 4 - Constants.Accuracy * 2, TestName = "TriangleInequalitySatisfiedWithAccuracy")]
        public void CreatedTriangleIsCorrectTest(double a, double b, double c)
        {
            var triangle = Triangle.Create(a, b, c);

            // Check:
            // All properties of the triangle have been initialized with the correct parameters
            // The order of the sides does not matter

            var (s1, s2, s3) = (triangle.Side1, triangle.Side2, triangle.Side3);

            Assert.That((s1, s2, s3).EqualTo((a, b, c), 1e-5));
        }

        [Test]
        public void AcceptMethodTest()
        {
            ResolveMethodWasCalledWithCorrectParametersTest<int>();
            ResolveMethodWasCalledWithCorrectParametersTest<Mock>();
        }

        private void ResolveMethodWasCalledWithCorrectParametersTest<T>()
        {
            double a = 5, b = 4, c = 3;
            var triangle = Triangle.Create(a, b, c);

            var resolver = repository.Create<IStrategyResolver>();
            var strategy = repository.Create<ITriangleStrategy<T>>();

            strategy.Setup(s => s.Execute(triangle)).Returns(It.IsAny<T>());
            resolver.Setup(r => r.Resolve<ITriangleStrategy<T>>()).Returns(strategy.Object);

            triangle.Accept<T>(resolver.Object);

            resolver.Verify(r => r.Resolve<ITriangleStrategy<T>>());
        }
    }
}
