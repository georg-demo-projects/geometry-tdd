using Geometry;
using Geometry.Internals;

namespace Examples
{
    internal class Rectangle : IRectangle
    {
        public double Hight { get; init; }   

        public double Width { get; init; }

        public Rectangle(double height, double width)
        {
            if (height < Constants.Accuracy || width < Constants.Accuracy)
            {
                throw new ArgumentException("Invalid rectangle parameters");
            }
            Hight = height;
            Width = width;
        }

        public T Accept<T>(IStrategyResolver strategyResolver)
        {
            return strategyResolver.Resolve<IRectangleStrategy<T>>().Execute(this);
        }
    }
}
