using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Restaurant.DAL.Test.Comparers
{
    internal class OrderDetailComparer : IEqualityComparer<OrderDetail>
    {
        public bool Equals([AllowNull] OrderDetail x, [AllowNull] OrderDetail y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id &&
                   x.OrderId == y.OrderId &&
                   x.Quantity == y.Quantity &&
                   x.ProductId == y.ProductId;
        }

        public int GetHashCode([DisallowNull] OrderDetail obj)
        {
            return obj.GetHashCode();
        }
    }
}
