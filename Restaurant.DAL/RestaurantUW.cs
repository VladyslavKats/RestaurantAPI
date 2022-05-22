using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class RestaurantUW : IRestaurantUW
    {
        private readonly RestaurantDbContext context;

        public RestaurantUW(RestaurantDbContext context)
        {
            this.context = context;
        }

        private IngredientRepository ingredientRepo;

        private ICategoryRepository categoryRepo;

        private IProductRepository productRepo;

        private IOrderRepository orderRepo;

        private IOrderDetailRepository orderDetailRepo;

        private IUserRepository userRepo;

        private IRoleRepository roleRepo;


        public IIngredientRepository Ingredients
        {
            get
            {
                if (ingredientRepo == null)
                {
                    ingredientRepo = new IngredientRepository(context);
                }
                return ingredientRepo;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (categoryRepo == null)
                {
                    categoryRepo = new CategoryRepository(context);
                }
                return categoryRepo;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (productRepo == null)
                {
                    productRepo = new ProductRepository(context);
                }
                return productRepo;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (orderRepo == null)
                {
                    orderRepo = new OrderRepository(context);
                }
                return orderRepo;
            }
        }

        public IOrderDetailRepository OrderDetails
        {
            get
            {
                if (orderDetailRepo == null)
                {
                    orderDetailRepo = new OrderDetailRepository(context);
                }
                return orderDetailRepo;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepo == null)
                {
                    userRepo = new UserRepository(context);
                }
                return userRepo;
            }
        }

        public IRoleRepository Roles 
        {
            get
            {
                if (roleRepo == null)
                {
                    roleRepo = new RoleRepository(context);
                }
                return roleRepo;
            }
        }
        

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
