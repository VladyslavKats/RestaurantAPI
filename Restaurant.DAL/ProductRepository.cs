using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestaurantDbContext context;

        public ProductRepository(RestaurantDbContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(Product entity)
        {
            await context.Products.AddAsync(entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            await Task.Run(() => context.Products.Remove(entity));
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Ingredients)
                .ToArrayAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetByIdWithDetailsAsync(int id)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            await Task.Run(() => context.Products.Update(entity));
        }
    }
}
