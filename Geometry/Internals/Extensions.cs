using Geometry.Utility;

namespace Geometry.Internals
{
    public static class DoubleExtensions
    {
        public static bool EqualTo(this double value1, double value2, double epsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }

    public static class DoubleTupleExtensions
    {
        public static bool EqualTo(this (double, double, double) value1, (double, double, double) value2, double epsilon)
        {
            var (a1, b1, c1) = Sort.Descending(value1.Item1, value1.Item2, value1.Item3);
            var (a2, b2, c2) = Sort.Descending(value2.Item1, value2.Item2, value2.Item3);

            return a1.EqualTo(a2, epsilon)
                && b1.EqualTo(b2, epsilon)  
                && c1.EqualTo(c2, epsilon);
        }
    }
}
