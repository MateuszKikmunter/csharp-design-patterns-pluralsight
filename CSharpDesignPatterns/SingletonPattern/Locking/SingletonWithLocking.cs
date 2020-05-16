using SingletonPattern.Utils;

namespace SingletonPattern.Locking
{
    public sealed class SingletonWithLocking
    {
        private static SingletonWithLocking? _instance = null;
        private static readonly object _padlock = new object();

        public static SingletonWithLocking Instance
        {
            get
            {
                Logger.Log("Calling instance!");
                lock(_padlock) // this lock is used on every reference to Singleton
                {
                    if(_instance == null)
                    {
                        _instance = new SingletonWithLocking();
                    }
                    return _instance;
                }
            }
        }

        private SingletonWithLocking()
        {
            Logger.Log("Calling constructor!");
        }
    }
}
