using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Interfaces
{
    public interface IRestaurantUW : IDisposable
    {
        IIngredientRepository Ingredients { get;}

        ICategoryRepository Categories { get;}

        IProductRepository Products { get;}

        IOrderRepository Orders { get;}

        IPurchaseRepository Purchases { get;}

        IUserRepository Users { get;}

        IRoleRepository Roles { get;}

        void Save();
    }
}
