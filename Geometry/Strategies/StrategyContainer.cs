using Geometry.Utility;

namespace Geometry.Strategies
{
    public class StrategyContainer : IStrategyContainer
    {
        public void Register<T>(T strategy) where T : class
        {
            if (strategy == null)
            {
                throw new ArgumentNullException($"Argument '{nameof(strategy)}' cannot be null");
            }
            container.Register(strategy);
        }

        public T Resolve<T>()
        {
            try
            {
                return container.Resolve<T>();
            }
            catch
            {
                throw new Exception($"No registered strategy for {typeof(T)}");
            }
        }

        private readonly DependencyContainer container = new DependencyContainer();
    }
}