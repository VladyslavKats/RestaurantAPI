using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Restaurant.DAL.Test.Comparers
{
    internal class UserComparer : IEqualityComparer<User>
    {
        public bool Equals([AllowNull] User x, [AllowNull] User y)
        {
            if(x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id &&
                   x.Login == y.Login &&
                   x.PhoneNumber == y.PhoneNumber &&
                   x.Password == y.Password && 
                   x.RoleId == y.RoleId;
                   
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }
}
