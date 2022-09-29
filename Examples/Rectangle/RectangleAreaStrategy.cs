
namespace Examples
{
    internal class RectangleAreaStrategy : IRectangleStrategy<double>
    {
        public double Execute(IRectangle rect)
        {
            return rect.Hight * rect.Width;
        }
    }
}
