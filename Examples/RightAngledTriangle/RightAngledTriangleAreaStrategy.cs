using Geometry.Figures;
using Geometry.Strategies;
using Geometry.Utility;

namespace Examples
{
    /// <summary>
    /// Right angled triangle area calculation
    /// </summary>
    internal class RightAngledTriangleAreaStrategy : ITriangleStrategy<double>
    {
        public RightAngledTriangleAreaStrategy(ITriangleStrategy<double> defaultStrategy)
        {
            this.defaultStrategy = defaultStrategy;
        }

        public double Execute(ITriangle triangle)
        {
            var (hypotenuse, l1, l2) = Sort.Descending(triangle.Side1, triangle.Side2, triangle.Side3);

            if (Pythagorean.Check(hypotenuse, l1, l2))
            {
                Console.WriteLine("--- Applied the strategy for a right-angled triangle ---");
                return CalcRightAngledTriangleArea(l1, l2);
            }
            return defaultStrategy.Execute(triangle);
        }

        private double CalcRightAngledTriangleArea(double leg1, double leg2)
        {
            return leg1 * leg2 / 2;
        }

        private ITriangleStrategy<double> defaultStrategy;
    }
}
