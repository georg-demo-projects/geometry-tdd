using System;
using Geometry.Internals;
using Geometry.Strategies;

namespace Geometry.Figures
{
    public class Circle : ICircle
    {
        public double Radius { get; init; }

        private Circle(double radius)
        {
            Radius = radius;
        }

        public static Circle Create(double radius)
        {
            if (radius < Constants.Accuracy)
            {
                throw new ArgumentException("Invalid circle parameters");
            }
            return new Circle(radius);
        }

        public T Accept<T>(IStrategyResolver strategyResolver)
        {
            return strategyResolver.Resolve<ICircleStrategy<T>>().Execute(this);
        }
    }
}
