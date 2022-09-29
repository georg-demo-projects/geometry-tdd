using Geometry.Strategies;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class StrategyContainerTests
    {
        [Test]
        public void RegisterNullReferencesTest()
        {
            var container = new StrategyContainer();
            Assert.Throws<ArgumentNullException>(() => container.Register<It.IsAnyType>(null));
        }

        [Test]
        public void NotRegisteredTest()
        {
            var container = new StrategyContainer();
            Assert.Throws<Exception>(() => container.Resolve<It.IsAnyType>());
        }

        [Test]
        public void ResolvedEqualToRegisteredTest()
        {
            var someObj = new Mock<Mock>().Object;

            var resolved = RegisterAndResolveTheSameType<Mock>(someObj);

            Assert.That(someObj, Is.SameAs(resolved));
        }

        private object RegisterAndResolveTheSameType<T>(T instance) where T : class
        {
            var container = new StrategyContainer();
            container.Register<T>(instance);
            return container.Resolve<T>();
        }
    }
}
