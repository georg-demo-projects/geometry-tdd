using Geometry.Figures;
using Geometry.Strategies;

namespace Examples
{
    internal class CirclePrintStrategy : ICircleStrategy<string>
    {
        public string Execute(ICircle circle)
        {
            return $"Circle Radius={circle.Radius}";
        }
    }
}
