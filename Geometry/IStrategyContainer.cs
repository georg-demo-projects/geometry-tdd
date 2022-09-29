
namespace Geometry
{
    public interface IStrategyContainer : IStrategyResolver
    {
        void Register<T>(T strategy) where T : class;
    }
}
