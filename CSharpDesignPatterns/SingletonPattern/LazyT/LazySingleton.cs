using SingletonPattern.Utils;
using System;

namespace SingletonPattern.LazyT
{
    public sealed class LazySingleton
    {
        public static readonly Lazy<LazySingleton> _lazy = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance
        {
            get
            {
                Logger.Log("Instance called!");
                return _lazy.Value;
            }
        }

        private LazySingleton()
        {
            Logger.Log("Constructor called!");
        }
    }
}
