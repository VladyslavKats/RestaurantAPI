using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RestaurantDbContext context;

        public IngredientRepository(RestaurantDbContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(Ingredient entity)
        {
            await context.Ingredients.AddAsync(entity);
        }

        public async Task DeleteAsync(Ingredient entity)
        {
            await Task.Run(() => context.Ingredients.Remove(entity));
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await context.Ingredients.ToArrayAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAllWithDetailsAsync()
        {
            return await context.Ingredients.Include(i => i.Products).ToArrayAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Ingredient> GetByIdWithDetailsAsync(int id)
        {
            return await context.Ingredients.Include(i => i.Products).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ingredient entity)
        {
            await Task.Run(() => context.Ingredients.Update(entity));
        }
    }
}
