using Restaurant.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Restaurant.DAL.Test.Comparers
{
    public class CategoryComparer : IEqualityComparer<Category>
    {

        public bool Equals([AllowNull] Category x, [AllowNull] Category y)
        {
            if (x == null && y == null)
                return true;
            
            if (x == null || y == null)
                return false;

            return x.Id == y.Id &&
                    x.Name == y.Name;
                    
        }

        public int GetHashCode([DisallowNull] Category obj)
        {
            return obj.GetHashCode();
        }
    }
}
