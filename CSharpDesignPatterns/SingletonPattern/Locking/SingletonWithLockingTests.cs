using SingletonPattern.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SingletonPattern.Locking
{
    public class SingletonWithLockingTests
    {
        private readonly ITestOutputHelper _output;
        public SingletonWithLockingTests(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(SingletonWithLocking));
            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonWithLocking>());

            var result = SingletonWithLocking.Instance;

            Assert.NotNull(result);
            Assert.IsType<SingletonWithLocking>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonWithLocking>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = SingletonWithLocking.Instance;
            Thread.Sleep(1);
            var result2 = SingletonWithLocking.Instance;
            Thread.Sleep(1);
            var result3 = SingletonWithLocking.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonWithLocking>());

            // configure logger to slow down the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<SingletonWithLocking>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(SingletonWithLocking.Instance);
            });

            var log = Logger.Output();
            try
            {
                Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
                Assert.Equal(3, log.Count(log => log.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
            }
        }
    }
}
