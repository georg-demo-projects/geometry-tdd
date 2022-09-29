using Geometry.Figures;

namespace Geometry.Strategies
{
    public interface ITriangleStrategy<T>
    {
        T Execute(ITriangle triangle);
    }
}