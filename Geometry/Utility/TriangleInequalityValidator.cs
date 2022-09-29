using Geometry.Internals;

namespace Geometry.Utility
{
    public static class TriangleInequality
    {
        public static bool Check(double side1, double side2, double side3)
        {
            return side1 + Constants.Accuracy < side2 + side3
                && side2 + Constants.Accuracy < side1 + side3
                && side3 + Constants.Accuracy < side1 + side2;
        }
    }
}
