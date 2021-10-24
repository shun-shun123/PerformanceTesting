using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class CapacityBenchmark
    {
        private const int DATA_SIZE = 100000;

        [Benchmark]
        public void WithCapacity()
        {
            var list = new List<int>(DATA_SIZE);
            for (var i = 0; i < DATA_SIZE; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void WithoutCapacity()
        {
            var list = new List<int>();
            for (var i = 0; i < DATA_SIZE; i++)
            {
                list.Add(i);
            }
        }
    }
}