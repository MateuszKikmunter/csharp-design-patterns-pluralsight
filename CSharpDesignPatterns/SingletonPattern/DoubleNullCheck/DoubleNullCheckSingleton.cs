using SingletonPattern.Utils;

namespace DubleNullCheckSingletonPattern.DoubleNullCheck
{
    public sealed class DoubleNullCheckSingleton
    {
        private static DoubleNullCheckSingleton _instance = null;
        private static readonly object padlock = new object();

        public static DoubleNullCheckSingleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                if (_instance == null) // only get a lock if the instance is null
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleNullCheckSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        private DoubleNullCheckSingleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
