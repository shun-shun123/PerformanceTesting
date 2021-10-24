using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class LinqVsPureBenchmark
    {
        private const int DATA_SIZE = 10000;
        
        private int[] numbers;
        
        [GlobalSetup]
        public void Setup()
        {
            numbers = Enumerable.Range(0, DATA_SIZE).ToArray();
        }

        [Benchmark]
        public void Pure()
        {
            var sum = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
        }

        [Benchmark]
        public void ForEach()
        {
            var sum = 0;
            foreach (var i in numbers)
            {
                sum += i;
            }
        }

        [Benchmark]
        public void Linq()
        {
            var sum = numbers.Sum();
        }
    }
}