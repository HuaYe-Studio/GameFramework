namespace Utility.Base.SingletonPattern
{
    public class EagerSingleton<T> where T : class, new()
    {
        public static T Instance { get; } = new T();

        protected EagerSingleton()
        {
        }
    }
}