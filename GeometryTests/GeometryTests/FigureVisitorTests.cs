using Geometry;
using Geometry.Visitors;
using Moq;

namespace GeometryTests
{
    [TestFixture]
    public class FigureVisitorTests
    {
        [Test]
        public void CallAcceptMethodTest()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);

            Mock<IStrategyContainer> strategyContainer = repository.Create<IStrategyContainer>();
            Mock<IFigure> figure = repository.Create<IFigure>();

            figure.Setup(f => f.Accept<double>(strategyContainer.Object)).Returns(It.IsAny<double>());

            var visitor = new FigureVisitor<double>(strategyContainer.Object);
            visitor.Visit(figure.Object);

            repository.VerifyAll();
        }
    }
}
