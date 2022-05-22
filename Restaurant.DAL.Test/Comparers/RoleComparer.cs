using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Restaurant.DAL.Test.Comparers
{
    internal class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals([AllowNull] Role x, [AllowNull] Role y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Role obj)
        {
            return obj.GetHashCode();
        }
    }
}
