
namespace Examples
{
    internal interface IRectangleStrategy<T>
    {
        T Execute(IRectangle rect);
    }
}
