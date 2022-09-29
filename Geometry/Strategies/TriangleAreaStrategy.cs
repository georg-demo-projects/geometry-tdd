using Geometry.Figures;

namespace Geometry.Strategies
{
    public class TriangleAreaStrategy : ITriangleStrategy<double>
    {
        public double Execute(ITriangle triangle)
        {
            double a = triangle.Side1;
            double b = triangle.Side2;
            double c = triangle.Side3;

            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
