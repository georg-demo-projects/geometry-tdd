
using Geometry.Figures;

namespace Geometry.Strategies
{
    public class CircleAreaStrategy: ICircleStrategy<double>
    {
        public double Execute(ICircle circle)
        {
            return Math.PI * circle.Radius * circle.Radius;
        }
    }
}
