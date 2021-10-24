using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class LocalFunctionBenchmark
    {
        private static int Count;
        
        [Benchmark]
        public void LambdaExpression()
        {
            Action action = () =>
            {
                Count++;
            };
            action.Invoke();
        }

        [Benchmark]
        public void LocalFunction()
        {
            void Increment()
            {
                Count++;
            }
            
            Increment();
        }
    }
}