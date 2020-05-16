using SingletonPattern.Utils;

namespace SingletonPattern.StaticConstructor
{
    public sealed class StaticConstructorSingleton
    {
        private static readonly StaticConstructorSingleton _instance = new StaticConstructorSingleton();

        //reading this will intialize the _instance
        public static readonly string GREETING = "HI!";

        public static StaticConstructorSingleton Instance
        {
            get
            {
                Logger.Log("Instance called!");
                return _instance;
            }
        }

        static StaticConstructorSingleton()
        {
            Logger.Log("Constructor called!");
        }
    }
}
