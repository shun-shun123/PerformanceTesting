using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class StructBenchmark
    {
        public class UserDataClass
        {
            public int Id;

            public string Name;

            public UserDataClass()
            {
                Id = 0;
                Name = "User_Name";
            }
        }

        public struct UserDataValue
        {
            public int Id;

            public string Name;

            public UserDataValue(int id = 0)
            {
                Id = 0;
                Name = "User_Name";
            }
        }

        [Benchmark]
        public void UserDataClassBenchmark()
        {
            var userDataClass = new UserDataClass();
        }

        [Benchmark]
        public void UserDataValueBenchmark()
        {
            var userDataValue = new UserDataValue();
        }
    }
}