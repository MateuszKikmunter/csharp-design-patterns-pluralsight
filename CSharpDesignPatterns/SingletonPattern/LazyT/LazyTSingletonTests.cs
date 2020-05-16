using SingletonPattern.Utils;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace SingletonPattern.LazyT
{
    public class LazyTSingletonTests
    {
        private readonly ITestOutputHelper _output;
        public LazyTSingletonTests(ITestOutputHelper output)
        {
            _output = output;

            // This doesn't work with a static readonly field
            //SingletonTestHelpers.Reset(typeof(Singleton));

            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = LazySingleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<LazySingleton>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = LazySingleton.Instance;
            Thread.Sleep(1);
            var result2 = LazySingleton.Instance;
            Thread.Sleep(1);
            var result3 = LazySingleton.Instance;

            var log = Logger.Output();

            // we can't check this since it depends on if this test is run alone or after others
            // Assert.Equal(1, log.Count(log => log.Contains("Constructor")));

            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }
    }
}
