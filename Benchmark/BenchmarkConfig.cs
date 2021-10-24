using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddExporter(HtmlExporter.Default);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.ShortRun);
        }
    }
}
