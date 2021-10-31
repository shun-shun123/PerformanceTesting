using Benchmark;
using BenchmarkDotNet.Running;

namespace PerformanceTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(CapacityBenchmark),
                typeof(StringBuilderBenchmark),
                typeof(StructBenchmark),
                typeof(ReadonlyStructBenchmark),
                typeof(BoxingBenchmark),
                typeof(LocalFunctionBenchmark),
                typeof(EqualityComparerBenchmark),
                typeof(EquatableForStruct),
                typeof(LinqVsPureBenchmark),
                typeof(ModuloBenchmark)
            });
            switcher.Run(args);
        }
    }
}
