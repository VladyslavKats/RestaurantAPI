using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantDbContext context;

        public CategoryRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await context.Categories.AddAsync(entity);
        }

        public async Task DeleteAsync(Category entity)
        {
            await Task.Run(() => context.Categories.Remove(entity)); 
        }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToArrayAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithDetailsAsync()
        {
            return await context.Categories.Include(c => c.Products).ThenInclude(p => p.Ingredients).ToArrayAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
           return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByIdWithDetailsAsync(int id)
        {
            return await context.Categories.Include(c => c.Products).ThenInclude(p => p.Ingredients).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
           await Task.Run(() => context.Categories.Update(entity));     
        }
    }
}
