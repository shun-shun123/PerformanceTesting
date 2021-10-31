using System;
using System.Runtime.CompilerServices;
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

        [Benchmark]
        public void LambdaToAction()
        {
            CallAction(() => { Count++; });
        }

        [Benchmark]
        public void LocalFunctionToAction()
        {
            void Increment()
            {
                Count++;
            }
            
            CallAction(Increment);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CallAction(Action action)
        {
            action();
        }
    }
}