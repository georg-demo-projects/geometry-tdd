using Geometry.Internals;

namespace Examples
{
    public static class Pythagorean
    {
        public static bool Check(double hypotenuse, double leg1, double leg2)
        {
            return leg1 > Constants.Accuracy
                && leg2 > Constants.Accuracy
                && hypotenuse > Constants.Accuracy
                && (leg1 * leg1 + leg2 * leg2).EqualTo(hypotenuse * hypotenuse, Constants.Accuracy);
        }
    }
}
