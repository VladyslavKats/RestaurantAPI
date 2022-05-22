using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Interfaces
{
    public interface IRestaurantUW
    {
        IIngredientRepository Ingredients { get;}

        ICategoryRepository Categories { get;}

        IProductRepository Products { get;}

        IOrderRepository Orders { get;}

        IOrderDetailRepository OrderDetails { get;}

        IUserRepository Users { get;}

        IRoleRepository Roles { get;}

        Task SaveAsync();
    }
}
