
using Geometry.Figures;

namespace Geometry.Strategies
{
    public interface ICircleStrategy<T>
    {
        T Execute(ICircle circle);
    }
}