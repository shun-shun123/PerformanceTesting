using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class StringBuilderBenchmark
    {
        private static string TemplateMessage => "Hello, World";

        [Benchmark]
        public void UseString()
        {
            string message = string.Empty;
            message += TemplateMessage;
        }

        [Benchmark]
        public void UseStringBuilder()
        {
            var stringBuilder = new StringBuilder(TemplateMessage.Length);
            stringBuilder.Append(TemplateMessage);
        }
    }
}