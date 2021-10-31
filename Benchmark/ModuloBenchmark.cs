using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class ModuloBenchmark
    {
        private const int TRY_COUNT = 100;

        private readonly Random _random = new Random();
        
        private int RandomInput => _random.Next(100, 1000);

        private int RandomMod => (int)Math.Pow(2, _random.Next(1, 4));

        private readonly int[] _randomInputArray = new int[TRY_COUNT];

        private readonly int[] _randomModArray = new int[TRY_COUNT];

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < TRY_COUNT; i++)
            {
                _randomInputArray[i] = RandomInput;
                _randomModArray[i] = RandomMod;
            }
        }
        
        /// <summary>
        /// %を使った剰余計算で、除数は定数にしておく
        /// </summary>
        [Benchmark]
        public void ModuleNormalBenchmark()
        {
            for (var i = 0; i < TRY_COUNT; i++)
            {
                ModuleNormal(_randomInputArray[i], 8);
            }
        }

        /// <summary>
        /// & を使った高速な剰余計算で、除数は定数にしておく
        /// ModuleNormalBenchmarkと大きな差が見られなかったので、下記に除数を実行時に決定するバージョンも実装してみる
        /// </summary>
        [Benchmark]
        public void ModuleAndBenchmark()
        {
            for (var i = 0; i < TRY_COUNT; i++)
            {
                ModuleAnd(_randomInputArray[i], 8);
            }
        }

        /// <summary>
        /// % を使った剰余計算で、除数も実行時に決定される
        /// （コンパイル時の最適化などはかけれないようにしておく）
        /// </summary>
        [Benchmark]
        public void ModuleNormalNotConstBenchmark()
        {
            for (var i = 0; i < TRY_COUNT; i++)
            {
                ModuleNormal(_randomInputArray[i], _randomModArray[i]);
            }
        }

        /// <summary>
        /// & を使った剰余計算で、除数は実行時に決定される
        /// （コンパイル時の最適化などはかけれないようにしておく）
        /// </summary>
        [Benchmark]
        public void ModuleAndNotConstBenchmark()
        {
            for (var i = 0; i < TRY_COUNT; i++)
            {
                ModuleAnd(_randomInputArray[i], _randomModArray[i]);
            }
        }
        
        private void ModuleNormal(int input, int mod)
        {
            var _ = input % mod;
        }

        private void ModuleAnd(int input, int mod)
        {
            var _ = input & (mod - 1);
        }
    }
}