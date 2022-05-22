using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Restaurant.DAL.Test.Comparers
{
    internal class IngredientComparer : IEqualityComparer<Ingredient>
    {
        public bool Equals([AllowNull] Ingredient x, [AllowNull] Ingredient y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Ingredient obj)
        {
            return obj.GetHashCode();
        }
    }
}
