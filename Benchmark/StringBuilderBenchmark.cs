using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class StringBuilderBenchmark
    {
        private const int TRY_COUNT = 100;
        
        private static string TemplateMessage => "Hello, World";

        [Benchmark]
        public void UseString()
        {
            string message = string.Empty;
            for (var i = 0; i < TRY_COUNT; i++)
            {
                message += TemplateMessage;
            }
        }

        [Benchmark]
        public void UseStringBuilder()
        {
            var stringBuilder = new StringBuilder(TemplateMessage.Length * TRY_COUNT);
            for (var i = 0; i < TRY_COUNT; i++)
            {
                stringBuilder.Append(TemplateMessage);
            }
        }
    }
}