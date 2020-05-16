using System;
using System.Reflection;

namespace SingletonPattern.Utils
{
    public static class SingletonTestHelpers
    {
        public static void Reset(Type type)
        {
            var info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
        }

        public static T GetPrivateStaticInstance<T>() where T : class
        {
            var type = typeof(T);
            var info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            return info.GetValue(null) as T;
        }
    }
}
