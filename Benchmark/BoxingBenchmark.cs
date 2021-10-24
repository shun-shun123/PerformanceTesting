using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class BoxingBenchmark
    {
        private static int Number => 10000;
        
        [Benchmark]
        public void BoxingToString()
        {
            var message = $"{Number}";
        }

        [Benchmark]
        public void NotBoxingToString()
        {
            var message = $"{Number.ToString()}";
        }
    }
}