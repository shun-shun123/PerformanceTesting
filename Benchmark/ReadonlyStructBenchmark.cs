using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class ReadonlyStructBenchmark
    {
        
        public class Data
        {
            public readonly Book BookData;

            public readonly ReadonlyBook ReadonlyBookData;

            public void BookDataExec()
            {
                
            }
        }
        
        public struct Book
        {
            public readonly int Id;

            public string Title;

            public string Author;

            public DateTime DateTime;

            public int NumOfAvailable;
            
            public void Execute() {}
        }

        public readonly struct ReadonlyBook
        {
            public readonly int Id;

            public readonly string Title;
            
            public readonly string Author;

            public readonly DateTime DateTime;

            public readonly int NumOfAvailable;
            
            public void Execute() {}
        }

        [Benchmark]
        public void SimpleStructCall()
        {
            var bookData = new Data();
            bookData.BookData.Execute();
        }

        [Benchmark]
        public void ReadonlyStructCall()
        {
            var bookData = new Data();
            bookData.ReadonlyBookData.Execute();
        }
    }
}