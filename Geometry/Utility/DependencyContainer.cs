namespace Geometry.Utility
{
    internal class DependencyContainer
    {
        private readonly Dictionary<Type, object> matchings = new Dictionary<Type, object>();

        public void Register<T>(T obj) where T : class
        {
            matchings[typeof(T)] = obj;
        }

        public T Resolve<T>()
        {
            return (T)matchings[typeof(T)];
        }
    }
}
