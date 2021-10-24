using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class EqualityComparerBenchmark
    {
        private const int TRY_COUNT = 10000;
        
        private class User
        {
            public int Id;

            public string Name;

            public int Age;

            public User(int id)
            {
                Id = id;
            }
        }

        private User[] _users = {
            new User(0),
            new User(1),
            new User(2),
            new User(3),
            new User(4),
            new User(5),
        };

        private class UserEqualityComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(User obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        private Dictionary<User, string> userWithAddressDictionary = new Dictionary<User, string>();
        
        private Dictionary<User, string> betterUserWithAddressDictionary = new Dictionary<User, string>(new UserEqualityComparer());

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < _users.Length; i++)
            {
                userWithAddressDictionary[_users[i]] = "";
                betterUserWithAddressDictionary[_users[i]] = "";
            }
        }

        [Benchmark]
        public void GetAddress()
        {
            var target = userWithAddressDictionary[_users[0]];
        }

        [Benchmark]
        public void GetBetterAddress()
        {
            var target = betterUserWithAddressDictionary[_users[0]];
        }
    }
}