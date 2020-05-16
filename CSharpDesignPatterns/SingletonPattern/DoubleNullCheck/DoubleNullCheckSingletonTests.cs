﻿using DubleNullCheckSingletonPattern.DoubleNullCheck;
using SingletonPattern.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SingletonPattern.DoubleNullCheck
{
    public class DoubleNullCheckSingletonTests
    {
        private readonly ITestOutputHelper _output;
        public DoubleNullCheckSingletonTests(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(DoubleNullCheckSingleton));
            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<DoubleNullCheckSingleton>());

            var result = DoubleNullCheckSingleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<DoubleNullCheckSingleton>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<DoubleNullCheckSingleton>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = DoubleNullCheckSingleton.Instance;
            Thread.Sleep(1);
            var result2 = DoubleNullCheckSingleton.Instance;
            Thread.Sleep(1);
            var result3 = DoubleNullCheckSingleton.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<DoubleNullCheckSingleton>());

            // configure logger to slow down the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<DoubleNullCheckSingleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(DoubleNullCheckSingleton.Instance);
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
