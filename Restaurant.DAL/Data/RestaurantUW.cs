using Restaurant.DAL.EF;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Data
{
    public class RestaurantUW : IRestaurantUW
    {
        private RestaurantDbContext context;

        private IIngredientRepository ingredients;
        private ICategoryRepository categories;
        private IProductRepository products;
        private IOrderRepository orders;
        private IPurchaseRepository purchases;
        private IUserRepository users;
        private IRoleRepository roles;
        public RestaurantUW(RestaurantDbContext context)
        {
            this.context = context;
        }
        public IIngredientRepository Ingredients
        {
            get
            {
                if (ingredients == null)
                {
                    ingredients = new IngredientRepository(context);

                }
                return ingredients;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = new CategoryRepository(context);
                }
                return categories;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (products == null)
                {
                    products = new ProductRepository(context);
                }
                return products;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new OrderRepository(context);
                }
                return orders;
            }
        }

        public IPurchaseRepository Purchases
        {
            get
            {
                if (purchases == null)
                {
                    purchases = new PurchaseRepository(context);
                }
                return purchases;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (users == null)
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roles == null)
                {
                    roles = new RoleRepository(context);
                }
                return roles;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
