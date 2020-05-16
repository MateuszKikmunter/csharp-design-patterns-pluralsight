using SingletonPattern.Utils;

namespace SingletonPattern.NaiveImplementation
{
    public sealed class Singleton
    {
        private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called!");
                return _instance ??= new Singleton();
            }
        }

        private Singleton()
        {
            Logger.Log("Constructor called!");
        }
    }
}
