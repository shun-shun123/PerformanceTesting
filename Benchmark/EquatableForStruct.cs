using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class EquatableForStruct
    {
        private User _user1 = default;

        private User _user2 = default;

        private UserByEquatable _userByEquatable1 = default;

        private UserByEquatable _userByEquatable2 = default;
        
        private struct User
        {
            public int Id;

            public string Name;

            public int Age;
        }

        private struct UserByEquatable : IEquatable<UserByEquatable>
        {
            public int Id;

            public string Name;

            public int Age;
            
            public bool Equals(UserByEquatable other)
            {
                if (Id != other.Id)
                {
                    return false;
                }

                if (Name != other.Name)
                {
                    return false;
                }

                if (Age != other.Age)
                {
                    return false;
                }

                return true;
            }

            public override bool Equals(object obj)
            {
                return obj is UserByEquatable other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id.GetHashCode(), Name.GetHashCode(), Age.GetHashCode());
            }
        }

        [Benchmark]
        public void SimpleStruct()
        {
            if (_user1.Equals(_user2))
            { }
        }

        [Benchmark]
        public void EquatableStruct()
        {
            if (_userByEquatable1.Equals(_userByEquatable2))
            { }
        }
    }
}