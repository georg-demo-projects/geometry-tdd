using Geometry.Utility;

namespace GeometryTests
{
    [TestFixture]
    internal class SortTests
    {
        [Test]
        public void DescendingSortTest()
        {
            double a = 10;
            double b = 20;
            double c = 50;

            var (s1, s2, s3) = Sort.Descending(b, c, a);

            Assert.That(s1, Is.EqualTo(c).Within(1e-5));
            Assert.That(s2, Is.EqualTo(b).Within(1e-5));
            Assert.That(s3, Is.EqualTo(a).Within(1e-5));
        }
    }
}
