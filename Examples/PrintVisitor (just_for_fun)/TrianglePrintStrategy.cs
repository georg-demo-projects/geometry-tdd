using Geometry.Figures;
using Geometry.Strategies;
using Geometry.Utility;

namespace Examples
{
    internal class TrianglePrintStrategy : ITriangleStrategy<string>
    {
        public string Execute(ITriangle t)
        {
            var (hypotenuse, l1, l2) = Sort.Descending(t.Side1, t.Side2, t.Side3);

            if (Pythagorean.Check(hypotenuse, l1, l2))
            {
                return $"Triangle (right angled) Hypotenuse={hypotenuse} L1={l1} L2={l2}";
            }
            else
            {
                return $"Triangle Side1={t.Side1} Side2={t.Side2} Side3={t.Side3}";
            }
        }
    }
}
