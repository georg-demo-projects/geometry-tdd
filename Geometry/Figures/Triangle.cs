using Geometry.Strategies;
using Geometry.Utility;

namespace Geometry.Figures
{
    public class Triangle : ITriangle
    {
        public virtual double Side1 { get; init; }

        public virtual double Side2 { get; init; }

        public virtual double Side3 { get; init; }

        private Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public static Triangle Create(double side1, double side2, double side3)
        {
            if (!TriangleInequality.Check(side1, side2, side3))
            {
                throw new ArgumentException("Invalid triangle parameters");
            }
            return new Triangle(side1, side2, side3);
        }

        public T Accept<T>(IStrategyResolver strategyResolver)
        {
            return strategyResolver.Resolve<ITriangleStrategy<T>>().Execute(this);
        }
    }
}
